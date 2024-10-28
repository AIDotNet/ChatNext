using ChatNext.Data.Model;

namespace ChatNext.Api.Infrastructure;

public class ResultFilter(ILogger<ResultFilter> logger) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            var result = await next(context);

            return result != null ? ResultDto.Success(result) : result;
        }
        catch (Exception e)
        {
            logger.LogError(e, "系统异常");
            return ResultDto.Fail("系统异常", e.Message);
        }
    }
}