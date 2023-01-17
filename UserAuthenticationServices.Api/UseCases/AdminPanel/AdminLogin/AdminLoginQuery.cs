using MediatR;

namespace UserAuthenticationServices.UseCases.AdminPanel.AdminLogin;

public class AdminLoginQuery : IRequest<Guid>
{
    public string Login { get; set; }
    public string Password { get; set; }
}