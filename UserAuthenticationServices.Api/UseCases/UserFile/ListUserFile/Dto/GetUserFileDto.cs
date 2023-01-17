namespace UserAuthenticationServices.UseCases.UserFile.ListUserFile.Dto;

public class GetUserFileDto
{
    public Guid FileId { get; set; }
    public string FileName { get; set; }
    public DateTime CreatedAt { get; set; }
    
}