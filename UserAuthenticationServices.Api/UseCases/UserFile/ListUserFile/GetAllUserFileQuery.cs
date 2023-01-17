using MediatR;
using UserAuthenticationServices.UseCases.UserFile.ListUserFile.Dto;

namespace UserAuthenticationServices.UseCases.UserFile.ListUserFile;

public class GetAllUserFileQuery : IRequest<List<GetUserFileDto>>
{
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
}