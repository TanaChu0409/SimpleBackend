using SimpleBackend.Application.Data;
using SimpleBackend.Application.Messaging;
using SimpleBackend.Domain.Shared;
using SimpleBackend.Domain.Users;

namespace SimpleBackend.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var user = User.Create(
            request.FirstName,
            request.LastName,
            request.Email);

        userRepository.Insert(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
