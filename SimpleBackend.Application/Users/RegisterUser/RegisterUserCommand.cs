using SimpleBackend.Application.Messaging;

namespace SimpleBackend.Application.Users.RegisterUser;
public sealed record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName) : ICommand<Guid>;
