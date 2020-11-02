using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaign.Application.Commands;
using Campaign.Application.Responses;
using Campaign.Core.Repositories;
using Campaign.Core.Entities;
using Campaign.Application.Mapper;


namespace Campaign.Application.Handlers
{
     
    public class RejectCampaignHandler : IRequestHandler<RejectCampaignCommand,int>
    {
//        private IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        public RejectCampaignHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository=campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
        }

        public async Task<int> Handle(RejectCampaignCommand request,CancellationToken cancellationToken)
    {
        var campaignEntity = CampaignMapper.Mapper.Map<Campaign.Core.Entities.Campaign>(request);
        var campaignInfo = await _campaignRepository.GetCampaignById(campaignEntity.campaign_id);
    campaignInfo.status=4;
    await _campaignRepository.UpdateAsync(campaignInfo);
    return campaignInfo.campaign_id;

       }

        
    }
}