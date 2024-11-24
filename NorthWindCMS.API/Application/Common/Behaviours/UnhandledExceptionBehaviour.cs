namespace NorthWindCMS.API.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            Log.Error(ex, "NorthWindCMS.API Request: Unhandled Exception for Request {Name} {@Request}",
                requestName, request);

            throw;
        }
    }
}
