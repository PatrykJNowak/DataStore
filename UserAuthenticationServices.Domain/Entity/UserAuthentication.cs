namespace UserAuthenticationServices.Domain.Entity;

public class UserAuthentication 
{
    public Guid AuthenticationId { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}