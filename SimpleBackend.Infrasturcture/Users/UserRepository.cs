using Microsoft.EntityFrameworkCore;
using SimpleBackend.Domain.Users;
using SimpleBackend.Infrasturcture.Database;

namespace SimpleBackend.Infrasturcture.Users;

internal sealed class UserRepository(UsersDbContext context) : IUserRepository
{
    public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Users.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public void Insert(User user)
    {
        context.Users.Add(user);
    }
}
