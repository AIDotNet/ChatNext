using ChatNext.Api.Infrastructure;
using ChatNext.Application.Contract.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace ChatNext.Api.Apis;

public static class UserApis
{
    public static IEndpointRouteBuilder MapUserApis(this IEndpointRouteBuilder app)
    {
        var user = app.MapGroup("/api/v1/users")
            .WithTags("Users")
            .RequireAuthorization(new AuthorizeAttribute())
            .AddEndpointFilter<ResultFilter>();

        user.MapGet("list",
                (IUserService userApis, string? keyword, int page, int pageSize) =>
                    userApis.GetListAsync(keyword, page, pageSize))
            .WithName("获取用户列表")
            .WithOpenApi(operation =>
            {
                operation.Summary = "获取用户列表";
                operation.Description = "获取用户列表";
                return operation;
            });

        user.MapGet("{id}",
                (IUserService userApis, Guid id) => userApis.GetAsync(id))
            .WithName("获取用户详情")
            .WithOpenApi(operation =>
            {
                operation.Summary = "获取用户详情";
                operation.Description = "获取用户详情";

                return operation;
            });

        user.MapDelete("{id}",
                (IUserService userApis, Guid id) => userApis.DeleteAsync(id))
            .WithName("删除用户")
            .WithOpenApi(operation =>
            {
                operation.Summary = "删除用户";
                operation.Description = "删除用户";

                return operation;
            });


        return app;
    }
}