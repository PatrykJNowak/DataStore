using MediatR;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.AdminPanel.ChangeUserLevel;

public class ChangeUserLevelCommandHandler : IRequestHandler<ChangeUserLevelCommand, string>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;
    
    public ChangeUserLevelCommandHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<string> Handle(ChangeUserLevelCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.AdminSessionId
        }, cancellationToken);

        var userData = _databaseContext.Users.Where(x => x.UserId == request.UserId);
        userData.First().UserLevel = "admin";

        await _databaseContext.SaveChangesAsync(cancellationToken);
        return "Done, user is graduate to admin now";
    }
}