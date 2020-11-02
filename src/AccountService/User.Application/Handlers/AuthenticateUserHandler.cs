using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Commands;
using User.Application.Responses;
using User.Core.Repositories;
using User.Core.Entities;
using User.Application.Mapper;


namespace User.Application.Handlers
{
     
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserResponse>
    {
//        private IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public AuthenticateUserHandler(IUserRepository userRepository)
        {
            _userRepository=userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }


        async Task<UserResponse> IRequestHandler<AuthenticateUserCommand, UserResponse>.Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<UserProfile>(request);
        if (userEntity == null)
        {
            throw new ApplicationException("Not Mapped");
        }
        var authenticateUser=await _userRepository.AddAsync(userEntity);
        var userResponse = UserMapper.Mapper.Map<UserResponse>(authenticateUser);
        return userResponse;
        }
    }
}