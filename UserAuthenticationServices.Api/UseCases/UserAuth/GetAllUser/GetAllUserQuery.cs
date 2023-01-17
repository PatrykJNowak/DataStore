using MediatR;
using UserAuthenticationServices.UseCases.UserAuth.GetAllUser.Dto;

namespace UserAuthenticationServices.UseCases.UserAuth.GetAllUser;

public class GetAllUserQuery : IRequest<List<UsersList>>
{
    public Guid SessionId { get; set; }
}