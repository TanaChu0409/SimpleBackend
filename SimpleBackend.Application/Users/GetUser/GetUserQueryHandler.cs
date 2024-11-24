using SimpleBackend.Application.Messaging;
using SimpleBackend.Domain.Shared;
using SimpleBackend.Domain.Users;

namespace SimpleBackend.Application.Users.GetUser;

internal sealed class GetUserQueryHandler(
    IUserRepository userRepository)
    : IQueryHandler<GetUserQuery, UserResponse>
{
    public async Task<Result<UserResponse>> Handle(
        GetUserQuery request,
        CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetAsync(request.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
        }

        var response = new UserResponse(user.Id, user.Email, user.FirstName, user.LastName);

        return Result.Success(response);
    }
}
