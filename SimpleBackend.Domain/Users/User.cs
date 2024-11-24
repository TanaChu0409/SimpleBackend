using SimpleBackend.Domain.Abstractions;

namespace SimpleBackend.Domain.Users;

public sealed class User : Entity
{
    private User()
    {
    }

    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public static User Create(
        string firstName,
        string lastName,
        string email)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
    }
}
