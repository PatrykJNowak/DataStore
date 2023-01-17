using MediatR;
using UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList.Dto;

namespace UserAuthenticationServices.UseCases.AdminPanel.GetActiveUserList;

public class GetActiveUserListQuery : IRequest<List<ActiveUserList>>
{
    public Guid AdminSessionId { get; set; }
}