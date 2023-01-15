namespace UserAuthenticationServices.Domain.Entity;

public class UserAuthorization
{
    public Guid AuthorizationId { get; set; }
    public Guid UserId { get; set; }
    public virtual User Users { get; set; }
    public DateTime CreatedAd { get; set; }
}