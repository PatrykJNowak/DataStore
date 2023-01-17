using FluentValidation;
using MediatR;
using UserAuthenticationServices.Infrastructure;

namespace UserAuthenticationServices.Validation.SessionValidation;

public class SessionValidationQueryHandler : IRequestHandler<SessionValidationQuery>
{
    private readonly DatabaseContext _databaseContext;

    public SessionValidationQueryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Unit> Handle(SessionValidationQuery request, CancellationToken cancellationToken)
    {
        if (request.SessionId == Guid.Empty)
            ThrowException();

        var session = _databaseContext.UserSessions.Where(x => x.SessionId == request.SessionId);
        if (!session.Any())
            ThrowException();

        var useDate = session.First().OpenedAt.AddMinutes(5);
        if(useDate < DateTime.UtcNow)
            ThrowException();
        else
            session.First().OpenedAt = DateTime.UtcNow;

        return Unit.Value;
    }

    private void ThrowException()
    {
        throw new ValidationException("Prohibited operation!");
    }
}