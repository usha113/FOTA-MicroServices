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
    public class RejectCampaignCommand : IRequest<int>
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