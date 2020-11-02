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
     
    public class StopCampaignHandler : IRequestHandler<StopCampaignCommand,int>
    {
//        private IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        
        public StopCampaignHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository=campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
        }

        public async Task<int> Handle(StopCampaignCommand request,CancellationToken cancellationToken)
    {
        var campaignEntity = CampaignMapper.Mapper.Map<Campaign.Core.Entities.Campaign>(request);
        //var userList = await _userRepository.GetUsersByRole(request.RoleId);
       var campaignInfo = await _campaignRepository.GetCampaignById(campaignEntity.campaign_id);
    campaignInfo.status=2;
    await _campaignRepository.UpdateAsync(campaignInfo);
    return campaignInfo.campaign_id;
    }

        
    }
}