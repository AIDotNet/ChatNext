using ChatNext.Api.Infrastructure;
using ChatNext.Application.Contract.System;
using ChatNext.Application.Contract.System.Input;

namespace ChatNext.Api.Apis;

public static class AuthorizationApis 
{
    public static IEndpointRouteBuilder MapAuthApis(this IEndpointRouteBuilder app)
    {
        var auth = app.MapGroup("/api/v1/auth")
            .WithTags("授权")
            .AddEndpointFilter<ResultFilter>();

        auth.MapPost("/token", (IAuthorizationService apis, AuthorizationInput input) => apis.TokenAsync(input))
            .WithName("Token授权")
            .WithOpenApi((operation =>
            {
                operation.Summary = "Token授权";
                operation.Description = "通过用户名密码获取Token";

                return operation;
            }));

        return app;
    }
}