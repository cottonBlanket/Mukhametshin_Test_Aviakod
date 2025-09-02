using FluentValidation;
using MediatR;
using Mukhametshin_Test_Aviakod.UseCases.Infrastructure.Interfaces;

namespace Mukhametshin_Test_Aviakod.UseCases.Infrastructure;

internal class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest, IValidated
{
    private readonly IServiceProvider _provider;

    public ValidationPipelineBehavior(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken ct
    )
    {
        var validator = _provider.GetService<IValidator<TRequest>>();
        
        if (validator is null)
        {
            throw new ArgumentException(
                $"Validator for type {typeof(TRequest).FullName} is not registered"
            );
        }
        
        await validator.ValidateAndThrowAsync(request, ct);
        return await next(ct);
    }
}