using MediatR;
using UserAuthenticationServices.Domain.Entity;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.UseCases.UserAuth.ChangeAuthenticationData;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserAuth.AddNewUser;

public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, string>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public AddNewUserCommandHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<string> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
    {
        var userId = Guid.NewGuid();
        var newUser = new User()
        {
            UserId = userId,
            Name = request.Name,
            SurName = request.SurName,
        };

        _databaseContext.Add(newUser);
        await _databaseContext.SaveChangesAsync(cancellationToken);

        await _mediator.Send(new ChangeAuthenticationDataCommand()
        {
            SessionId = Guid.Parse("04ecaf30-2a77-45c7-8ae9-e349c17e2a85"),
            UserId = userId,
            Login = request.Login,
            Password = request.Password
        }, cancellationToken);
        
        return "Done";
    }
}