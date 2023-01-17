using MediatR;

namespace UserAuthenticationServices.UseCases.AdminPanel.ChangeUserLevel;

public class ChangeUserLevelCommand : IRequest<string>
{
    public Guid AdminSessionId { get; set; }
    public Guid UserId { get; set; }
}