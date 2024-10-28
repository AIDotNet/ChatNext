using ChatNext.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore.Users;

public class UserRepository(ChatNextDbContext context) : IUserRepository
{
    public Task<List<User>> GetListAsync(string keyword, int page, int pageSize)
    {
        var query = context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(x => x.Username.Contains(keyword) || x.Email.Contains(keyword));
        }

        return query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    public Task<long> GetCountAsync(string keyword)
    {
        var query = context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(x => x.Username.Contains(keyword) || x.Email.Contains(keyword));
        }

        return query.LongCountAsync();
    }

    public Task<User?> GetAsync(Guid id)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task RemoveAsync(Guid id)
    {
        await context.Users.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }
}