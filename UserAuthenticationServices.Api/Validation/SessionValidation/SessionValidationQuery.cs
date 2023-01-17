using MediatR;

namespace UserAuthenticationServices.Validation.SessionValidation;

public class SessionValidationQuery : IRequest
{
    public Guid SessionId { get; set; }
}