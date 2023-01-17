using MediatR;

namespace UserAuthenticationServices.UseCases.UserAuth.AddNewUser;

public class AddNewUserCommand : IRequest<string>
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}