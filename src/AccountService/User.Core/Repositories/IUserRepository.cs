using System;
using System.Threading.Tasks;
using System.Text;
using User.Core.Repositories.Base;
using System.Collections.Generic;
using User.Core.Entities;

namespace User.Core.Repositories
{
    public interface IUserRepository : IRepository<User.Core.Entities.UserProfile>
    {
       // Task<IEnumerable<User.Core.Entities.User>> GetUsersByRole(int roleId);
        Task<User.Core.Entities.UserProfile> AuthenticateUser(User.Core.Entities.UserProfile user);

        
        UserProfile GetProfile(string email);
        bool VerifyPassword(string password, Byte[] hash, Byte[] salt);

        string GenerateTokenForUser(UserProfile user);

        Task<bool> ResetPassword(UserProfile profile);
        string GenerateTempPassword(int length);
       (byte[] PasswordHash, byte[] SaltHash) GenerateHashPassword(string password);
       

       Task<bool> ForgotPassword (UserProfile profile);
    }
}