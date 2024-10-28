namespace ChatNext.Domain.Users;

public interface IUserRepository
{
    Task<List<User>> GetListAsync(string keyword, int page, int pageSize);
    
    Task<long> GetCountAsync(string keyword);
    
    Task<User?> GetAsync(Guid id);
    
    Task<User?> GetByUsernameAsync(string username);
    
    Task<User?> GetByEmailAsync(string email);
    
    Task RemoveAsync(Guid id);
}