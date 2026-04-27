using MediatR;
using Shared.Domain;

namespace Shared.Application.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    where TResponse : notnull
{
}