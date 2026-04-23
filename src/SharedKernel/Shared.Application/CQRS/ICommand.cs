using MediatR;
using URLShortener.Domain;

namespace Shared.Application.CQRS;

public interface ICommand : IRequest<Result<Unit>>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}