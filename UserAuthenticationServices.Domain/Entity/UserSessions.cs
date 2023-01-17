namespace UserAuthenticationServices.Domain.Entity;

public class UserSessions
{
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
    public DateTime OpenedAt { get; set; }
    public virtual User User { get; set; }
} 