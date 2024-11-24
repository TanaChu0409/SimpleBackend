using SimpleBackend.Application.Messaging;

namespace SimpleBackend.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
