using MediatR;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.AdminPanel.RemoveUserSession;

public class RemoveUserSessionCommandHandler : IRequestHandler<RemoveUserSessionCommand, string>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;
    
    public RemoveUserSessionCommandHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<string> Handle(RemoveUserSessionCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.AdminSessionId
        }, cancellationToken);

        var sessionToDelete = _databaseContext.UserSessions
            .Where(x => x.User.UserId == request.UserId);

        _databaseContext.RemoveRange(sessionToDelete);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return "User session closed";

    }
}