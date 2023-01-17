using MediatR;
using UserAuthenticationServices.Infrastructure;
using UserAuthenticationServices.UseCases.UserFile.DownloadFile.Dto;
using UserAuthenticationServices.Validation.SessionValidation;

namespace UserAuthenticationServices.UseCases.UserFile.DownloadFile;

public class DownloadUserFileQueryHandler : IRequestHandler<DownloadUserFileQuery, ContentFileData>
{
    private readonly DatabaseContext _databaseContext;
    private readonly IMediator _mediator;

    public DownloadUserFileQueryHandler(DatabaseContext databaseContext, IMediator mediator)
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }

    public async Task<ContentFileData> Handle(DownloadUserFileQuery request, CancellationToken cancellationToken)
    {
        await _mediator.Send(new SessionValidationQuery()
        {
            SessionId = request.SessionId
        }, cancellationToken);

        var file = _databaseContext.UserContentFiles
            .Where(x => x.FileId == request.FileId)
            .Select(x => new ContentFileData()
            {
                FileContent = x.FileContent,
                FileName = x.FileName
            });

        return file.First();
    }
}