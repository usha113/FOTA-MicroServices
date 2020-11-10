using System;
using Campaign.Core.Entities;

namespace Campaign.Application.Request
{
    public class CampaignRequest
    {
        
       public int campaign_id { get; set; }
       public string campaign_name  { get; set; }
       public string campaign_desc  { get; set; }

       
       public DateTime campaign_start_date { get; set; }
       public DateTime campaign_end_date { get; set; }
       public short is_active { get; set; }
       public short status { get; set; }
       
       public int approver_id { get;set; }
       public int vehiclegroup_id { get;set; }
       public int firmware_id { get;set; }
       public int ecu_id { get;set; }
       public DateTime approval_date { get; set; }
       public short approval_status { get; set; }

            }
}
