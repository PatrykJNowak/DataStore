using MediatR;
using UserAuthenticationServices.UseCases.UserFile.DownloadFile.Dto;

namespace UserAuthenticationServices.UseCases.UserFile.DownloadFile;

public class DownloadUserFileQuery : IRequest<ContentFileData>
{
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
    public Guid FileId { get; set; }
}