using Microsoft.EntityFrameworkCore;
using SimpleBackend.Application.Data;
using SimpleBackend.Domain.Users;
using SimpleBackend.Infrasturcture.Users;

namespace SimpleBackend.Infrasturcture.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
