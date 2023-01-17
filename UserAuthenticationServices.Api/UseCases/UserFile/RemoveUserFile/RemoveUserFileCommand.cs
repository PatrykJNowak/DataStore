using MediatR;

namespace UserAuthenticationServices.UseCases.UserFile.RemoveUserFile;

public class RemoveUserFileCommand : IRequest<string>
{
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
    public Guid FileId { get; set; }
}