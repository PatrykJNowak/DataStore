using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationServices.UseCases.UserAuth.AddNewUser;
using UserAuthenticationServices.UseCases.UserAuth.ChangeAuthenticationData;
using UserAuthenticationServices.UseCases.UserAuth.GetAllUser;
using UserAuthenticationServices.UseCases.UserAuth.GetAllUser.Dto;
using UserAuthenticationServices.UseCases.UserAuth.UserLogin;

namespace UserAuthenticationServices.Controllers;

[ApiController]
[Route("userAuthenticationController/1.0")]
public class UserAuthenticationController : ControllerBase
{
    [HttpGet("GetAllUser")]
    public async Task<List<UsersList>> CreatNewUser(
        [FromServices] IMediator mediator,
        [FromQuery] Guid sessionId)
    {
        var result = mediator.Send(new GetAllUserQuery()
        {
            SessionId = sessionId
        });
        return await result;
    }
    
    [HttpPost("AddNewUser")]
    public async Task<string> CreatNewUser(
        [FromServices] IMediator mediator,
        [FromQuery] string name,
        [FromQuery] string surName,
        [FromQuery] string login,
        [FromQuery] string password)
    {
        var result = mediator.Send(new AddNewUserCommand()
        {
            Name = name,
            SurName = surName,
            Login = login,
            Password = password
        });
        return await result;
    }

    [HttpPut("ChangeUserPasswordOrLogin")]
    public async Task<string> ChangeUserData(
        [FromServices] IMediator mediator,
        [FromQuery] Guid sessionId,
        [FromQuery] Guid userId,
        [FromQuery] string newLogin,
        [FromQuery] string newPassword)
    {
        var result = mediator.Send(new ChangeAuthenticationDataCommand()
        {
            SessionId = sessionId,
            UserId = userId,
            Login = newLogin,
            Password = newPassword
        });
        return await result;
    }

    [HttpPost("Login")]
    public async Task<Guid> LoginUser(
        [FromServices] IMediator mediator,
        [FromQuery] string login,
        [FromQuery] string password)
    {
        var result = mediator.Send(new UserLoginQuery()
        {
            Login = login,
            Password = password
        });
        return await result;
    }
}