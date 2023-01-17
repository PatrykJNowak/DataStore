using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationServices.UseCases.UserFile.AddNewFile;
using UserAuthenticationServices.UseCases.UserFile.DownloadFile;
using UserAuthenticationServices.UseCases.UserFile.DownloadFile.Dto;
using UserAuthenticationServices.UseCases.UserFile.ListUserFile;
using UserAuthenticationServices.UseCases.UserFile.ListUserFile.Dto;
using UserAuthenticationServices.UseCases.UserFile.RemoveUserFile;

namespace UserAuthenticationServices.Controllers;

[ApiController]
[Route("cloudSystem/1.0")]
public class UserFilesDistributionController : ControllerBase
{
    [HttpPost("AddNewFile")]
    public async Task<Guid> CreatNewUser(
        [FromServices] IMediator mediator,
        [FromQuery] Guid sessionId,
        [FromQuery] Guid userId,
        IFormFile file,
        CancellationToken cancellationToken)
    {
        var result = mediator.Send(new AddNewFileCommand()
        {
            SessionId = sessionId,
            UserId = userId,
            FileContent = file
        }, cancellationToken);
        return await result;
    }
    
    [HttpDelete("RemoveFile")]
    public async Task<string> RemoveUserFile(
        [FromServices] IMediator mediator,
        [FromQuery] Guid sessionId,
        [FromQuery] Guid userId,
        [FromQuery] Guid fileId,
        CancellationToken cancellationToken)
    {
        var result = mediator.Send(new RemoveUserFileCommand()
        {
            SessionId = sessionId,
            UserId = userId,
            FileId = fileId,
        }, cancellationToken);
        return await result;
    }
    
    [HttpGet("GetAllUserFile")]
    public async Task<List<GetUserFileDto>> GetAllUserFile(
        [FromServices] IMediator mediator,
        [FromQuery] Guid sessionId,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken)
    {
        var result = mediator.Send(new GetAllUserFileQuery()
        {
            SessionId = sessionId,
            UserId = userId,
        }, cancellationToken);
        return await result;
    }
    
    [HttpGet("DownloadFile")]
    public async Task<FileContentResult> DownloadFile(
        [FromServices] IMediator mediator,
        [FromQuery] Guid sessionId,
        [FromQuery] Guid userId,
        [FromQuery] Guid fileId,
        CancellationToken cancellationToken)
    {
        var file = await mediator.Send(new DownloadUserFileQuery()
        {
            SessionId = sessionId,
            UserId = userId,
            FileId = fileId
        }, cancellationToken);
        return File(file.FileContent, "application/octet-stream", file.FileName);
    }
    
} 