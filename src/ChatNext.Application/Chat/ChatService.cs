using ChatNext.Application.Contract.Chat;
using ChatNext.Application.Contract.Chat.Dto;
using ChatNext.Domain.Chat;
using Gnarly.Data;
using MapsterMapper;

namespace ChatNext.Application.Chat;

public class ChatService(ISessionGroupRepository sessionGroupRepository, IMapper mapper)
    : IChatService, IScopeDependency
{
    public async Task<List<SessionGroupsDto>> GetSessionsAsync(string? keyword)
    {
        var result = await sessionGroupRepository.GetSessionsAsync(keyword);

        if (result.Count == 0)
        {
            result.Add(new SessionGroups
            {
                Id = Guid.Empty,
                Name = "默认分组",
                IsDefault = true
            });
        }

        return mapper.Map<List<SessionGroupsDto>>(result);
    }

    public async Task RemoveAsync(Guid id)
    {
        await sessionGroupRepository.RemoveAsync(id);
    }

    public async Task RenameAsync(Guid id, string name)
    {
        await sessionGroupRepository.RenameAsync(id, name);
    }

    public async Task AddAsync(SessionGroupsDto sessionGroups)
    {
        var entity = mapper.Map<SessionGroups>(sessionGroups);

        await sessionGroupRepository.AddAsync(entity);
    }

    public async Task AddSessionAsync(Guid groupId, SessionDto session)
    {
        var entity = mapper.Map<Session>(session);
        session.GroupId = groupId;
        await sessionGroupRepository.AddSessionAsync(groupId, entity);
    }

    public async Task RemoveSessionAsync(long sessionId)
    {
        await sessionGroupRepository.RemoveSessionAsync(sessionId);
    }

    public async Task<SessionDto?> GetSessionAsync(long sessionId)
    {
        var result = await sessionGroupRepository.GetSessionAsync(sessionId);

        return mapper.Map<SessionDto?>(result);
    }
}