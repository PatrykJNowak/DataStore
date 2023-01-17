using MediatR;

namespace UserAuthenticationServices.UseCases.AdminPanel.RemoveUserSession;

public class RemoveUserSessionCommand : IRequest<string>
{
    public Guid AdminSessionId { get; set; }
    public Guid UserId { get; set; }
}