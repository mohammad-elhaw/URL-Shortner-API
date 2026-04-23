using MediatR;
using URLShortener.Domain;

namespace Shared.Application.CQRS;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result<Unit>>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> 
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}