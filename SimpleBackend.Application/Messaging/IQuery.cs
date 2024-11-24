using MediatR;
using SimpleBackend.Domain.Shared;

namespace SimpleBackend.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
