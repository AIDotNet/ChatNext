using ChatNext.Application.Contract.Chat.Dto;

namespace ChatNext.Application.Contract.Chat;

public interface IChatService
{
    /// <summary>
    /// 获取会话列表
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    Task<List<SessionGroupsDto>> GetSessionsAsync(string? keyword);
    
    /// <summary>
    /// 删除分组
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task RemoveAsync(Guid id);

    /// <summary>
    /// 重命名分组
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    Task RenameAsync(Guid id, string name);
    
    /// <summary>
    /// 添加分组
    /// </summary>
    /// <returns></returns>
    Task AddAsync(SessionGroupsDto sessionGroups);

    /// <summary>
    /// 添加会话
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="session"></param>
    /// <returns></returns>
    Task AddSessionAsync(Guid groupId, SessionDto session);

    /// <summary>
    /// 移除会话
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    Task RemoveSessionAsync(long sessionId);

    /// <summary>
    /// 获取会话
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    Task<SessionDto?> GetSessionAsync(long sessionId);
}