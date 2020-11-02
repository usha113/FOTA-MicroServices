using System;
using Campaign.Core.Entities;

namespace Campaign.Application.Responses
{
    public class CampaignResponse
    {
        
       public int campaign_id { get; set; }
       public string campaign_name  { get; set; }
       public string campaign_desc  { get; set; }

       
       public DateTime campaign_start_date { get; set; }
       public DateTime campaign_end_date { get; set; }
       public short is_active { get; set; }
       public short status { get; set; }
       

            }
}
