using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Responses;
using User.Application.Commands;
using User.Core.Entities;
using AutoMapper;
using User.Application.Mapper;

namespace User.Application.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserProfile,UserResponse>().ReverseMap();
            CreateMap<UserProfile,AuthenticateUserCommand>().ReverseMap();
        }

    }
}
