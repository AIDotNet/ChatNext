using ChatNext.Api.Infrastructure;
using ChatNext.Application.Contract.Chat;
using ChatNext.Application.Contract.Chat.Dto;

namespace ChatNext.Api.Apis;

public static class ChatApis
{
    public static IEndpointRouteBuilder MapChatApis(this IEndpointRouteBuilder app)
    {
        var chat = app.MapGroup("/api/v1/chat")
            .WithTags("聊天服务")
            .AddEndpointFilter<ResultFilter>();

        chat.MapGet("/sessions", (IChatService apis, string? keyword) => apis.GetSessionsAsync(keyword))
            .WithName("获取会话列表")
            .WithOpenApi((operation =>
            {
                operation.Summary = "获取会话列表";
                operation.Description = "获取会话列表";


                return operation;
            }));

        chat.MapDelete("/sessions/{id}", (IChatService apis, Guid id) => apis.RemoveAsync(id))
            .WithName("删除分组")
            .WithOpenApi((operation =>
            {
                operation.Summary = "删除分组";
                operation.Description = "删除分组";

                return operation;
            }));

        chat.MapPut("/sessions/{id}", (IChatService apis, Guid id, string name) => apis.RenameAsync(id, name))
            .WithName("重命名分组")
            .WithOpenApi((operation =>
            {
                operation.Summary = "重命名分组";
                operation.Description = "重命名分组";

                return operation;
            }));

        chat.MapPost("/sessions", (IChatService apis, SessionGroupsDto sessionGroups) => apis.AddAsync(sessionGroups))
            .WithName("添加分组")
            .WithOpenApi((operation =>
            {
                operation.Summary = "添加分组";
                operation.Description = "添加分组";

                return operation;
            }));

        chat.MapPost("/sessions/{groupId}/session",
                (IChatService apis, Guid groupId, SessionDto session) => apis.AddSessionAsync(groupId, session))
            .WithName("添加会话")
            .WithOpenApi((operation =>
            {
                operation.Summary = "添加会话";
                operation.Description = "添加会话";

                return operation;
            }));

        chat.MapDelete("/sessions/session/{sessionId}",
                (IChatService apis, long sessionId) => apis.RemoveSessionAsync(sessionId))
            .WithName("移除会话")
            .WithOpenApi((operation =>
            {
                operation.Summary = "移除会话";
                operation.Description = "移除会话";

                return operation;
            }));

        chat.MapGet("/sessions/session/{sessionId}",
                (IChatService apis, long sessionId) => apis.GetSessionAsync(sessionId))
            .WithName("获取会话")
            .WithOpenApi((operation =>
            {
                operation.Summary = "获取会话";
                operation.Description = "获取会话";

                return operation;
            }));

        return app;
    }
}