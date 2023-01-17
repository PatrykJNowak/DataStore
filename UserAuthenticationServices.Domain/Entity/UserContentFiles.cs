namespace UserAuthenticationServices.Domain.Entity;

public class UserContentFiles
{
    public Guid FileId { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public byte[] FileContent { get; set; }
    public string FileName { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}