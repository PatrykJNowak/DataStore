namespace UserAuthenticationServices.Domain.Entity;

public class User 
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public virtual ICollection<UserAuthorization> UserAuthorizations { get; set; }
}