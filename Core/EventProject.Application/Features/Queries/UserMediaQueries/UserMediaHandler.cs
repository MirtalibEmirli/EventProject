using EventProject.Application.Abstractions.IHttpContextUser;
using EventProject.Application.Repositories.UserMediaFileRepo;
using EventProject.Application.ResponseModels.Generics;
using MediatR;

namespace EventProject.Application.Features.Queries.UserMediaQueries;

public class GetUserMediaQuery : IRequest<ResponseModel<string>>;

public class GetUserMediaHandler(
    ICurrentUserService currentUserService,
    IUserMediaFileRead userMediaFileRead
) : IRequestHandler<GetUserMediaQuery, ResponseModel<string>>
{
    private readonly ICurrentUserService _currentUserService = currentUserService;
    private readonly IUserMediaFileRead _userMediaFileRead = userMediaFileRead;

    public async Task<ResponseModel<string>> Handle(GetUserMediaQuery request, CancellationToken cancellationToken)
    {
        var userId = _currentUserService.GetUserId();

        var userMedia = _userMediaFileRead
            .GetWhere(x => x.UserId == userId && x.IsDeleted!=true)
            .OrderByDescending(x => x.CreatedDate)
            .FirstOrDefault();

        if (userMedia == null)
        {
            return new ResponseModel<string>
            {
                Message= "Şəkil yüklənməyib!.",
            };
        }

        var fullPath = $"{userMedia.Path}/{userMedia.FileName}";

        return new ResponseModel<string> { Data=userMedia.FileName};
    }
}
