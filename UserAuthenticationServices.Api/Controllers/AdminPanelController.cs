using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationServices.UseCases.AdminPanel.AdminLogin;
using UserAuthenticationServices.UseCases.AdminPanel.ChangeUserLevel;
using UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList;
using UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList.Dto;
using UserAuthenticationServices.UseCases.AdminPanel.RemoveUserSession;
using UserAuthenticationServices.UseCases.UserAuth.GetAllUser;
using UserAuthenticationServices.UseCases.UserAuth.GetAllUser.Dto;

namespace UserAuthenticationServices.Controllers;

[ApiController]
[Route("AdminPanelController/1.0")]
public class AdminPanelController : ControllerBase 
{
    [HttpPost("Login")]
    public async Task<Guid> LoginUser(
        [FromServices] IMediator mediator,
        [FromQuery] string login,
        [FromQuery] string password)
    {
        var result = mediator.Send(new AdminLoginQuery()
        {
            Login = login,
            Password = password
        });
        return await result;
    }
    
    [HttpPut("ChangeUserLevel")]
    public async Task<string> ChangeUserLevel(
        [FromServices] IMediator mediator,
        [FromQuery] Guid adminSessionId,
        [FromQuery] Guid userId)
    {
        var result = mediator.Send(new ChangeUserLevelCommand()
        {
            AdminSessionId = adminSessionId,
            UserId = userId
        });
        return await result;
    }
    
    [HttpGet("GetActiveUserList")]
    public async Task<List<ActiveUserList>> GetActiveUserList(
        [FromServices] IMediator mediator,
        [FromQuery] Guid adminSessionId)
    {
        var result = mediator.Send(new GetActiveUserListQuery()
        {
            AdminSessionId = adminSessionId,
        });
        return await result;
    }
    
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
    
    [HttpDelete("RemoveUserSession")]
    public async Task<string> RemoveUserSession(
        [FromServices] IMediator mediator,
        [FromQuery] Guid adminSessionId,
        [FromQuery] Guid userId)
    {
        var result = mediator.Send(new RemoveUserSessionCommand()
        {
            AdminSessionId = adminSessionId,
            UserId = userId
            
        });
        return await result;
    }
    
    
}