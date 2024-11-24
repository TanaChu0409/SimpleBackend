using MediatR;
using SimpleBackend.Domain.Shared;

namespace SimpleBackend.Application.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;
