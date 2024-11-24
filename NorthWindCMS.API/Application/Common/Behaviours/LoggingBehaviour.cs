namespace NorthWindCMS.API.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        Log.Information("NorthWindCMS.API Request: {Name} {@Request}",
            requestName, request);

        return await next();
    }
}
