using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaign.Application.Responses;
using Campaign.Core.Entities;



namespace Campaign.Application.Commands
{
    public class InitiateCampaignCommand : IRequest<CampaignResponse>
    {
    //     public InitiateCampaignCommand(string campaign_name,string campaign_desc,DateTime campaign_start_date,DateTime campaign_end_date)
    //    {
    //        campaignName = campaign_name;
    //        campaignDesc = campaign_desc;
    //        campaignStartdate = campaign_start_date;
    //        campaignEnddate=campaign_end_date;
    //    }
        
       //public long campaign_id { get;  }

           //public long campaign_id { get;  }

    //    public CampaignRequest campaignRequest{get;set;}
    //    public InitiateCampaignCommand(CampaignRequest campaignRequest)
    //    {
    //        this.campaignRequest= campaignRequest;
    //    }
       
       public string campaign_name  { get; set;}
       public string campaign_desc  { get; set; }


       
       public DateTime campaign_start_date { get;set; }
       public DateTime campaign_end_date { get; set;}
       public bool is_active { get;set;}
       public short status { get;set; }

        public long approver_id { get; set;}
       public long vehiclegroup_id { get; set;}
       public Firmware firmware { get; set;}
       public long ecu_id { get; set;}
       public DateTime approval_date { get; set;}
       public short approval_status { get; set;}

        // public string firmware_name { get; set; }
        // public string current_firmware_version { get; set; }
        // public string current_firmware_link { get; set; }
        // public string previous_firmware_version { get; set; }
        // public string previous_firmware_link { get; set; }
        


    }
}