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
     
    public class InitiateCampaignHandler : IRequestHandler<InitiateCampaignCommand,CampaignResponse>
    {
        
//        private IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
    
        
        public InitiateCampaignHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository=campaignRepository ?? throw new ArgumentNullException(nameof(campaignRepository));
        }

        public async Task<CampaignResponse> Handle(InitiateCampaignCommand request,CancellationToken cancellationToken)
    {
        //var userList = await _userRepository.GetUsersByRole(request.RoleId);
        
        
        var campaignEntity = CampaignMapper.Mapper.Map<Campaign.Core.Entities.Campaign>(request);
        if (campaignEntity == null)
        {
            throw new ApplicationException("Not Mapped");
        }
        campaignEntity.is_active=1;
        campaignEntity.status=1;
        var newCampaign = await _campaignRepository.AddAsync(campaignEntity);
        var campaignResponse = Campaign.Application.Mapper.CampaignMapper.Mapper.Map<CampaignResponse>(newCampaign);
        return campaignResponse;
    }

        
    }
}