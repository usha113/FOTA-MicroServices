using System;
using Campaign.Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Application.Responses
{
    public class CampaignResponse
    {
        
       public long campaign_id { get; set; }
       public string campaign_name  { get; set; }
       public string campaign_desc  { get; set; }

       
       public DateTime campaign_start_date { get; set; }
       public DateTime campaign_end_date { get; set; }
       public bool is_active { get; set; }
       public short status { get; set; }
       
       public long approver_id { get;set; }
       public long vehiclegroup_id { get;set; }
       public Firmware firmware { get; set;}
       public long ecu_id { get;set; }
       public DateTime approval_date { get; set; }
       public short approval_status { get; set; }

            }
}
