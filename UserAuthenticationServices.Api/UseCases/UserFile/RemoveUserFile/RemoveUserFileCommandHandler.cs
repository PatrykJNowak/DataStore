using MediatR;
using Microsoft.EntityFrameworkCore;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserFile.RemoveUserFile;

public class RemoveUserFileCommandHandler : IRequestHandler<RemoveUserFileCommand, string>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public RemoveUserFileCommandHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<string> Handle(RemoveUserFileCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.SessionId
        }, cancellationToken);

        var dataFromDb = _databaseContext.UserContentFiles
            .Where(x => x.UserId == request.UserId)
            .FirstOrDefaultAsync(x => x.FileId == request.FileId, cancellationToken: cancellationToken);

        _databaseContext.Remove(dataFromDb);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return "File removed";
    }
}