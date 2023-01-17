using System.Globalization;

namespace UserAuthenticationServices.Domain.Entity;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string UserLevel { get; set; }
    public virtual ICollection<UserContentFiles> UserContentFiles { get; set; }
    public virtual ICollection<UserAuthentication> UserAuthentication { get; set; }
    public virtual ICollection<UserSessions> UserSessions { get; set; }
}