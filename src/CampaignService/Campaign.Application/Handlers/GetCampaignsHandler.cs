using MediatR;
using Campaign.Application.Mapper;
using Campaign.Application.Queries;
using Campaign.Application.Responses;
using Campaign.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Campaign.Application.Handlers
{
    public class GetCampaignsHandler : IRequestHandler<GetCampaignsQuery, IEnumerable<CampaignResponse>>
    {
        private readonly ICampaignRepository _campaignRepository;

        public GetCampaignsHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
        }

        public async Task<IEnumerable<CampaignResponse>> Handle(GetCampaignsQuery request, CancellationToken cancellationToken)
        {
            var campaigns = await _campaignRepository.GetCampaigns();
            
            var campaignsInfo = CampaignMapper.Mapper.Map<IEnumerable<CampaignResponse>>(campaigns);
            return campaignsInfo;
        }    
    }
}
