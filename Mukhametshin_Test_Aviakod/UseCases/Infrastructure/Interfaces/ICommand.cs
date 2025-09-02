using MediatR;

namespace Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;

public interface ICommand : IRequest;

public interface ICommand<out TResponse> : IRequest<TResponse>;