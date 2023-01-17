using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationServices.Domain.Entity;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserFile.AddNewFile;

public class AddNewFileCommandHandler : IRequestHandler<AddNewFileCommand, Guid>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public AddNewFileCommandHandler(IMediator mediator, DatabaseContext databaseContext)
    {
        _mediator = mediator;
        _databaseContext = databaseContext;
    }

    public async Task<Guid> Handle(AddNewFileCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.SessionId
        }, cancellationToken);

        var newFileId = Guid.NewGuid();

        var ms = new MemoryStream();
        await request.FileContent.CopyToAsync(ms, cancellationToken);
        var fileBytes = ms.ToArray();

        var userContent = new UserContentFiles
        {
            FileId = newFileId,
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow,
            FileName = request.FileContent.FileName,
            Description = request.Description,
            FileContent = fileBytes
        };

        _databaseContext.Add(userContent);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return newFileId;
    }
}