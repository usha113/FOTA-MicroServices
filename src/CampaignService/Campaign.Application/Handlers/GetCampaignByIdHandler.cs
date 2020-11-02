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
    public class GetCampaignByIdHandler : IRequestHandler<GetCampaignByIdQuery, CampaignResponse>
    {
        private readonly ICampaignRepository _campaignRepository;

        public GetCampaignByIdHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
        }

        public async Task<CampaignResponse> Handle(GetCampaignByIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _campaignRepository.GetCampaignById(request.Campaign_id);
            
            var campaignInfo = CampaignMapper.Mapper.Map<CampaignResponse>(campaign);
            return campaignInfo;
        }    
    }
}
