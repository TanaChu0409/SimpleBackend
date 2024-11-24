using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SimpleBackend.Application.Users.RegisterUser;
using SimpleBackend.Domain.Shared;
using SimpleBackend.Presentation.ApiResults;
using SimpleBackend.Presentation.Endpoints;

namespace SimpleBackend.Presentation.Users;

internal sealed class RegisterUser : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("users/register", async (Request request, ISender sender) =>
        {
            Result<Guid> result = await sender.Send(
                new RegisterUserCommand(
                    request.Email,
                    request.FirstName,
                    request.LastName));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Users);
    }

    internal sealed class Request
    {
        public string Email { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }
    }
}
