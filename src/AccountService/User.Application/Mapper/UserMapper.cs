using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace User.Application.Mapper
{
    public static class UserMapper
    {
        private static readonly Lazy<IMapper> Lazy=new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<UserMappingProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });
    public  static IMapper Mapper=>Lazy.Value;
    }
}
