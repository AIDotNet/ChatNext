using ChatNext.Domain.Chat;
using Microsoft.EntityFrameworkCore;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore.Chat;

public class SessionGroupRepository(ChatNextDbContext dbContext) : ISessionGroupRepository
{
    public async Task<List<SessionGroups>> GetSessionsAsync(string keyword)
    {
        var query = dbContext.SessionGroups.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(x => x.Name.Contains(keyword));
        }

        var result = await query.ToListAsync();

        var groupIds = result.Select(x => x.Id).ToList();

        var sessions = await dbContext.Sessions.Where(x => groupIds.Contains(x.GroupId)).ToListAsync();

        foreach (var session in sessions)
        {
            var group = result.FirstOrDefault(x => x.Id == session.GroupId);

            if (group != null)
            {
                group.Sessions.Add(session);
            }
        }

        return result;
    }

    public async Task RemoveAsync(Guid id)
    {
        await dbContext.SessionGroups.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task RenameAsync(Guid id, string name)
    {
        await dbContext.SessionGroups.Where(x => x.Id == id)
            .ExecuteUpdateAsync(y => y.SetProperty(x => x.Name, name));
    }

    public async Task AddAsync(SessionGroups sessionGroups)
    {
        if(await dbContext.SessionGroups.AnyAsync(x => x.Name == sessionGroups.Name))
        {
            throw new ArgumentException("分组名称已存在");
        }
        
        await dbContext.SessionGroups.AddAsync(sessionGroups);
        
        await dbContext.SaveChangesAsync();
    }

    public async Task AddSessionAsync(Guid groupId, Session session)
    {
        var group = await dbContext.SessionGroups.FirstOrDefaultAsync(x => x.Id == groupId);

        if (group == null)
        {
            throw new ArgumentException("分组不存在");
        }

        session.GroupId = groupId;

        await dbContext.Sessions.AddAsync(session);

        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveSessionAsync(long sessionId)
    {
        await dbContext.Sessions.Where(x => x.Id == sessionId)
            .ExecuteDeleteAsync();
    }

    public async Task<Session?> GetSessionAsync(long sessionId)
    {
        return await dbContext.Sessions.FirstOrDefaultAsync(x => x.Id == sessionId);
    }
}