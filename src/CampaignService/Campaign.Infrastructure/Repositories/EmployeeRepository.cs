using System;
using System.Threading.Tasks;
using System.Text;
using Campaign.Infrastructure.Repositories.Base;
using Campaign.Core.Entities;
using Campaign.Core.Repositories;
using Campaign.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Collections.Generic;


namespace Campaign.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Campaign.Core.Entities.EmployeeModel>, IEmployeeRepository
    {
         //#region Constants
        // const string PASSWORD_CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        // const int PASSWORD_LENGTH = 8;
        // const int MAX_ATTEMPTS = 5;
        // const int TOKEN_VALIDITY = 3;
        // #endregion

        #region Readonly Variables
       // private readonly ApplicationSettings _appSettings;
        //private readonly CampaignContext _dbContxt;
        //private readonly SmtpClient _client;
        //private readonly Repository _repository;
       // private long userId;
        //public void SetUser(long UserId) => this.userId = UserId;
        #endregion
        

        public EmployeeRepository(CampaignContext dbContext) : base(dbContext)
        {
            
        }

       

        // public async Task<IEnumerable<Core.Entities.User>> GetUsersByRole(int roleId)
        // {
        //     var userList= await _dbContext.Users.Where(o =>o.RoleId == roleId)
        //                     .ToListAsync();

        //     return userList;

        // }
        // public async Task<Campaign> InitiateCampaign(Campaign campaign)
        // {
        //  return await _dbContext.Campaign.Ass
        // }

           }
}

