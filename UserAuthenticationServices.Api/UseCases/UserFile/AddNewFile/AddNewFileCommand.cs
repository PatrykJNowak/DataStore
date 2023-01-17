using MediatR;

namespace UserAuthenticationServices.UseCases.UserFile.AddNewFile;

public class AddNewFileCommand : IRequest<Guid>
{
    public Guid SessionId { get; set; }
    public IFormFile FileContent { get; set; }
    public Guid UserId { get; set; }
    public string? Description { get; set; }
}