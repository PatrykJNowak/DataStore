using MediatR;
using UserAuthenticationServices.Domain.Entity;
using UserAuthenticationServices.Infrastructure;

namespace UserAuthenticationServices.UseCases.AdminPanel.AdminLogin;

public class AdminLoginQueryHandler : IRequestHandler<AdminLoginQuery, Guid>
{
    private readonly DatabaseContext _databaseContext;

    public AdminLoginQueryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<Guid> Handle(AdminLoginQuery request, CancellationToken cancellationToken)
    {
        var userData = _databaseContext.UserAuthentications.Where(x => x.User.UserLevel == "admin").Where(x => x.Login == request.Login)
            .FirstOrDefault(x => x.Password == request.Password);

        var sessionId = Guid.Empty;

        if (userData != null)
        {
            sessionId = Guid.NewGuid();
            var newSession = new UserSessions()
            {
                UserId = userData.UserId,
                SessionId = sessionId,
                OpenedAt = DateTime.UtcNow
            };

            _databaseContext.Add(newSession);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        return sessionId;
    }
}