using System;
using System.Threading.Tasks;
using System.Text;
using User.Infrastructure.Repositories.Base;
using User.Infrastructure.Helper;
using User.Infrastructure.Helper.CustomException;
using User.Core.Entities;
using User.Core.Repositories;
using User.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Collections.Generic;
using System.Security.Cryptography;




namespace User.Infrastructure.Repositories
{
    public class UserRepository : Repository<Core.Entities.UserProfile>, IUserRepository
    {
         #region Constants
        const string PASSWORD_CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const int PASSWORD_LENGTH = 8;
        const int MAX_ATTEMPTS = 5;
        const int TOKEN_VALIDITY = 3;
        #endregion

        #region Readonly Variables
        private readonly ApplicationSettings _appSettings;
        private readonly UserProfileContext _dbContxt;
        private readonly SmtpClient _client;
        private readonly IEmailHelper _email;
        private long userId;
        public void SetUser(long UserId) => this.userId = UserId;
        #endregion

private static Random random = new Random();

        public UserRepository(UserProfileContext dbContext,IOptions<ApplicationSettings> appSettings, SmtpClient client, IEmailHelper emailHelper) : base(dbContext)
        {
            _appSettings = appSettings.Value;
            _dbContxt = dbContext;
            _client = client;
            _email = emailHelper;
        }

        // public async Task<IEnumerable<Core.Entities.User>> GetUsersByRole(int roleId)
        // {
        //     var userList= await _dbContext.Users.Where(o =>o.RoleId == roleId)
        //                     .ToListAsync();

        //     return userList;

        // }

        public async Task<UserProfile> AuthenticateUser(UserProfile profile)
        {
           UserProfile user = GetProfile(profile.Email ?? null);
            if(user == null)
                throw new UserNotFoundException();

                #region
                if (user.PasswordHash == null || user.SaltHash == null) 
                    throw new LoginFailedException();

                bool isPasswordMatch = VerifyPassword(profile.Password, user.PasswordHash, user.SaltHash);

                if(!isPasswordMatch)
                {
                    user.FailureAttempt = Convert.ToInt16(user.FailureAttempt.Value + 1);
                    await _dbContxt.SaveChangesAsync();
                    throw new WrongPasswordException(user.FailureAttempt.Value);
                }
                #endregion
                user.Token = GenerateTokenForUser(user);
                await _dbContxt.SaveChangesAsync();
                user.PasswordHash = null;
                user.SaltHash = null;
                user.Password = null;
                return user;
        }

        public UserProfile GetProfile(string email)
        {
            email = !string.IsNullOrEmpty(email) ? email.ToLower() : null;
            if (!string.IsNullOrEmpty(email))
                return _dbContxt.UserProfile.Include(i => i.Role).FirstOrDefault(a => a.Email.ToLower() == email);

            return _dbContxt.UserProfile.Include(i => i.Role)
            .FirstOrDefault(f => !string.IsNullOrEmpty(email) ? f.Email.ToLower() == email : false);
        }

    
        public bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            try
            {
                if (!string.IsNullOrEmpty(password))
                {
                    PasswordHash pwdHash = new PasswordHash(salt, hash);
                    if (!pwdHash.Verify(password))
                        throw new UnauthorizedAccessException();

                    return true;
                }
            }
            catch (Exception)
            {
                //swallow this exception as this will be handled in the caller function
            }
            return false;
        }
        
        public string GenerateTokenForUser(UserProfile user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, user?.UserId.ToString() ?? ""),
                }),
                Expires = DateTime.UtcNow.AddDays(TOKEN_VALIDITY),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> ForgotPassword(UserProfile profile)
        {
            var user = GetProfile(profile.Email);
            if (user == null)
                throw new UserNotFoundException();

            var tempPassword = GenerateTempPassword(PASSWORD_LENGTH);
            var hash = GenerateHashPassword(tempPassword);
            user.PasswordHash = hash.PasswordHash;
            user.SaltHash = hash.SaltHash;
            await _dbContext.SaveChangesAsync();
            await _email.SendEmail(_client, user.Email, EmailType.ResetPassword, $"FOTA Temporary Password - {tempPassword}");
            return true;
        }
        public string GenerateTempPassword(int length)
        {
            var passwordString = new string(Enumerable.Repeat(PASSWORD_CHARACTERS, length)
                          .Select(s => s[random.Next(s.Length)]).ToArray());
            RNGCryptoServiceProvider cryptRNG = new RNGCryptoServiceProvider();
            byte[] passwordBuffer = Encoding.ASCII.GetBytes(passwordString);
            cryptRNG.GetBytes(passwordBuffer);
            return Convert.ToBase64String(passwordBuffer);
        }

        public (byte[] PasswordHash, byte[] SaltHash) GenerateHashPassword(string password)
        {
            PasswordHash hash = new PasswordHash(password);
            byte[] hashBytes = hash.ToArray();

            return (PasswordHash: hash.Hash, SaltHash: hash.Salt);
        }

     public async Task<bool> ResetPassword (UserProfile profile)
        {
            var user = GetProfile(profile.Email);
            if (user == null || profile.Password == null || profile.NewPassword == null)
                throw new UserNotFoundException();

            var isPasswordMatch = VerifyPassword(profile.Password, user.PasswordHash, user.SaltHash);
            if(!isPasswordMatch)
            {
                user.FailureAttempt = Convert.ToInt16(user.FailureAttempt.Value + 1);
                await _dbContext.SaveChangesAsync();
                throw new WrongPasswordException(user.FailureAttempt.Value);
            }

            var hash = GenerateHashPassword(profile.NewPassword);
            user.PasswordHash = hash.PasswordHash;
            user.SaltHash = hash.SaltHash;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        

    }
}

