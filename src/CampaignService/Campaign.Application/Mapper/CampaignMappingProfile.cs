using System;
using System.Collections.Generic;
using System.Text;
using Campaign.Application.Responses;
using Campaign.Application.Commands;
using Campaign.Core.Entities.Base;
using AutoMapper;

namespace Campaign.Application.Mapper
{
    public class CampaignMappingProfile : AutoMapper.Profile
    {
        public CampaignMappingProfile()
                {
                    CreateMap<Campaign.Core.Entities.Campaign, InitiateCampaignCommand>().ReverseMap();
                    CreateMap<Campaign.Core.Entities.Campaign, ApproveCampaignCommand>().ReverseMap();
                    CreateMap<Campaign.Core.Entities.Campaign, RejectCampaignCommand>().ReverseMap();
                    CreateMap<Campaign.Core.Entities.Campaign, StopCampaignCommand>().ReverseMap();
            CreateMap<Campaign.Core.Entities.Campaign,CampaignResponse>().ReverseMap();

            
           // CreateMap<User.Core.Entities.UserProfile,AddUserCommand>().ReverseMap();
        }
    }
}
