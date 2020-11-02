using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Application.Responses;
using User.Application.Commands;
using Microsoft.AspNetCore.Authorization;
using System.Net;


namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

       
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserResponse>),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UserResponse>>> AuthenticateUser([FromBody] AuthenticateUserCommand userCommand)
        {
            
            var users=await _mediator.Send(userCommand);
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand resetPasswordCommand)
        {
            var resetPasswordUserProfile=await _mediator.Send(resetPasswordCommand);
            return Ok(resetPasswordUserProfile);
            
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ForgotPasswordCommand forgotPasswordCommand)
        {
            var forgotPasswordCommandUserProfile=await _mediator.Send(forgotPasswordCommand);
            return Ok(forgotPasswordCommandUserProfile);

           
        }

    }
}