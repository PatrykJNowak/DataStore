using MediatR;

namespace UserAuthenticationServices.UseCases.UserAuth.ChangeAuthenticationData;

public class ChangeAuthenticationDataCommand : IRequest<string>
{
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

}