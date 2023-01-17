using MediatR;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.UseCases.UserAuth.GetAllUser.Dto;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserAuth.GetAllUser;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UsersList>>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public GetAllUserQueryHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<List<UsersList>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.SessionId
        }, cancellationToken);

        var allUserFromDb = _databaseContext.Users.Select(x => new UsersList
        {
            UserId = x.UserId,
            Name = x.Name,
            SurName = x.SurName
        }).ToList();

        return allUserFromDb;
    }
}