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
       public string campaign_name  { get; }
       public string campaign_desc  { get; }


       
       public DateTime campaign_start_date { get; }
       public DateTime campaign_end_date { get; }
       public short is_active { get;}
       public short status { get; }

       



    }
}