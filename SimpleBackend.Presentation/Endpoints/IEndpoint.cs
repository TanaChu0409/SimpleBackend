using Microsoft.AspNetCore.Routing;

namespace SimpleBackend.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
