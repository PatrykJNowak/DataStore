using MediatR;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList.Dto;

namespace UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList;

public class GetActiveUserListQueryHandler : IRequestHandler<GetActiveUserListQuery, List<ActiveUserList>>
{
    private readonly DatabaseContext _databaseContext;

    public GetActiveUserListQueryHandler(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<ActiveUserList>> Handle(GetActiveUserListQuery request, CancellationToken cancellationToken)
    {
        var activeUserList = _databaseContext.UserSessions
                .Where(x => x.OpenedAt.AddMinutes(5) < DateTime.UtcNow)
                .Select(x => new ActiveUserList()
                {
                    UserId = x.User.UserId,
                    UserName = x.User.Name,
                    UserSurName = x.User.SurName,
                    UserSessionId = x.SessionId,
                    UserLevel = x.User.UserLevel,
                    SessionFinishAt = x.OpenedAt.AddMinutes(5)
                }).ToList();

        return activeUserList;
    }
}