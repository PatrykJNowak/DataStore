using MediatR;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.UseCases.UserFile.ListUserFile.Dto;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserFile.ListUserFile;

public class GetAllUserFileQueryHandler : IRequestHandler<GetAllUserFileQuery, List<GetUserFileDto>>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public GetAllUserFileQueryHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<List<GetUserFileDto>> Handle(GetAllUserFileQuery request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.SessionId,
        }, cancellationToken);

        var allUserFile = _databaseContext.UserContentFiles
            .Where(x => x.UserId == request.UserId)
            .Select(x => new GetUserFileDto()
            {
                FileId = x.FileId,
                FileName = x.FileName,
                CreatedAt = x.CreatedAt
            }).ToList();

        return allUserFile;
    }
}