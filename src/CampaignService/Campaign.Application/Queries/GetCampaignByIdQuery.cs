using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaign.Application.Responses;
using Campaign.Core.Entities;

namespace Campaign.Application.Queries
{
    public class GetCampaignByIdQuery : IRequest<CampaignResponse>
    {
       public int Campaign_id { get; private set; }

        public GetCampaignByIdQuery(int campaign_id)
        {
            this.Campaign_id = campaign_id;
        }

    }
}