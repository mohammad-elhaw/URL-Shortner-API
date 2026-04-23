using MediatR;
using URLShortener.Domain;

namespace Shared.Application.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    where TResponse : notnull
{
}