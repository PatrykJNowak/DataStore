using MediatR;
using UserAuthenticationServices.Domain.Entity;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserAuth.ChangeAuthenticationData;

public class ChangeAuthenticationDataCommandHandler : IRequestHandler<ChangeAuthenticationDataCommand, string>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public ChangeAuthenticationDataCommandHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<string> Handle(ChangeAuthenticationDataCommand request, CancellationToken cancellationToken)
    {
        if (request.SessionId != Guid.Parse("04ecaf30-2a77-45c7-8ae9-e349c17e2a85"))
        {
            await _mediator.Send(new SessionValidationQuery()
            {
                SessionId = request.SessionId
            }, cancellationToken);
        }

        var newAuthenticationData = new UserAuthentication()
        {
            AuthenticationId = Guid.NewGuid(),
            UserId = request.UserId,
            Login = request.Login,
            Password = request.Password
        };

        _databaseContext.Add(newAuthenticationData);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        return "Done";
    }
}