using ChatNext.Application.Contract.Users.Dto;
using ChatNext.Data.Model;

namespace ChatNext.Application.Contract.Users;

public interface IUserService
{
    Task<PagingResult<UserDto>> GetListAsync(string? keyword, int page, int pageSize);

    Task<UserDto> GetAsync(Guid id);

    Task DeleteAsync(Guid id);
}