using ChatNext.Application.Contract.Users;
using ChatNext.Application.Contract.Users.Dto;
using ChatNext.Data.Model;
using ChatNext.Domain.Users;
using Gnarly.Data;
using MapsterMapper;

namespace ChatNext.Application.Users;

public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService, IScopeDependency
{
    public async Task<PagingResult<UserDto>> GetListAsync(string keyword, int page, int pageSize)
    {
        var result = await userRepository.GetListAsync(keyword, page, pageSize);

        var total = await userRepository.GetCountAsync(keyword);

        return new PagingResult<UserDto>(mapper.Map<List<UserDto>>(result), total);
    }

    public async Task<UserDto> GetAsync(Guid id)
    {
        var result = await userRepository.GetAsync(id);

        return mapper.Map<UserDto>(result);
    }

    public async Task DeleteAsync(Guid id)
    {
        await userRepository.RemoveAsync(id);
    }
}