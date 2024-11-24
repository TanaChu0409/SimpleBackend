using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SimpleBackend.Application.Users.GetUser;
using SimpleBackend.Domain.Shared;
using SimpleBackend.Presentation.ApiResults;
using SimpleBackend.Presentation.Endpoints;

namespace SimpleBackend.Presentation.Users;

internal sealed class GetUserProfile : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("users/profile/{userId}", async (Guid userId, ISender sender) =>
        {
            Result<UserResponse> result = await sender.Send(
                new GetUserQuery(userId));

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Users);
    }
}
