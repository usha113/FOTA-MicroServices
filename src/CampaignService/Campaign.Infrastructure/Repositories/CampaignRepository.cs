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
    public class CampaignRepository : Repository<Campaign.Core.Entities.Campaign>, ICampaignRepository
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
        

        public CampaignRepository(CampaignContext dbContext) : base(dbContext)
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

        public async Task<IEnumerable<Campaign.Core.Entities.Campaign>> GetCampaigns()
        {
        
           var campaigns = await _dbContext.Campaign.ToListAsync();
           return campaigns;
    
        }

         public async Task<Campaign.Core.Entities.Campaign> GetCampaignById(long id)
         {
             var campaign = await _dbContext.Campaign.FirstOrDefaultAsync(a=> a.campaign_id == id);
             return campaign;
         }

         public async Task<Campaign.Core.Entities.Firmware> GetFirmwareById(long id)
         {
             var firmware = await _dbContext.Firmware.FirstOrDefaultAsync(a=> a.firmware_id == id);
             return firmware;
         }

         public async Task<Campaign.Core.Entities.VehicleGroup> GetVehiclegroupById(long id)
         {
             var vehiclegroup_id = await _dbContext.VehicleGroup.FirstOrDefaultAsync(a=> a.vehiclegroup_id == id);
             return vehiclegroup_id;
         }

         public async Task<Campaign.Core.Entities.ECU> GetECUById(long id)
         {
             var ecu = await _dbContext.ECU.FirstOrDefaultAsync(a=> a.ecu_id == id);
             return ecu;
         }

         public async Task<Campaign.Core.Entities.Approver> GetApproverById(long id)
         {
             var approver = await _dbContext.Approver.FirstOrDefaultAsync(a=> a.approver_id == id);
             return approver;
         }
    }
}

