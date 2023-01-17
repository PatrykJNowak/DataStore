using MediatR;

namespace UserAuthenticationServices.UseCases.UserAuth.UserLogin;

public class UserLoginQuery : IRequest<Guid>
{
    public string Login { get; set; }
    public string Password { get; set; }
}