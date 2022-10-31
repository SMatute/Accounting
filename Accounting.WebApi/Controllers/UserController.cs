using Accounting.Application.Common;
using Accounting.Application.Queries;
using Accounting.Application.Responses;
using Accounting.Domain.Entity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Accounting.WebApi.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class UserController: ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Usuarios")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<List<User>> Get()
        {
             return (List<User>) await _mediator.Send( new GetUsersQuery());
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
    }
}
