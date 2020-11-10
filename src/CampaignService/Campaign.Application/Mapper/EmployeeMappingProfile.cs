using System;
using System.Collections.Generic;
using System.Text;
using Campaign.Application.Responses;
using Campaign.Application.Commands;
using Campaign.Core.Entities.Base;
using AutoMapper;

namespace Campaign.Application.Mapper
{
    public class EmployeeMappingProfile : AutoMapper.Profile
    {
        public EmployeeMappingProfile()
                {
                    CreateMap<Campaign.Core.Entities.EmployeeModel, EmployeeCommand>().ReverseMap();
                   
            CreateMap<Campaign.Core.Entities.EmployeeModel,EmployeeResponse>().ReverseMap();

            
           // CreateMap<User.Core.Entities.UserProfile,AddUserCommand>().ReverseMap();
        }
    }
}
