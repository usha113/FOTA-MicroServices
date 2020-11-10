using System;
using System.Threading.Tasks;
using System.Text;
using Campaign.Core.Repositories.Base;
using System.Collections.Generic;
using Campaign.Core.Entities;


namespace Campaign.Core.Repositories
{
    public interface ICampaignRepository : IRepository<Campaign.Core.Entities.Campaign>
 {    
         Task<IEnumerable<Campaign.Core.Entities.Campaign>> GetCampaigns();
         Task<Campaign.Core.Entities.Campaign> GetCampaignById(long id);

         Task<Campaign.Core.Entities.VehicleGroup> GetVehiclegroupById(long id);

         Task<Campaign.Core.Entities.Firmware> GetFirmwareById(long id);

         Task<Campaign.Core.Entities.ECU> GetECUById(long id);
         Task<Campaign.Core.Entities.Approver> GetApproverById(long id);

        // Task InitiateCampaign(Campaign.Core.Entities.Campaign campaign);


        // Task ApproveCampaign(Campaign.Core.Entities.Campaign campaign);

        // Task RejectCampaign(Campaign.Core.Entities.Campaign campaign);

        // Task StopCampaign(Campaign.Core.Entities.Campaign campaign);

        
        
        
    }
}