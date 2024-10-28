using ChatNext.Application.Contract.Users;
using ChatNext.Application.Contract.Users.Dto;
using ChatNext.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChatNext.Api.Controller;

[Route("/api/v1/[controller]/[action]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<PagingResult<UserDto>> GetListAsync(string keyword, int page, int pageSize)
    {
        return await userService.GetListAsync(keyword, page, pageSize);
    }

    [HttpGet]
    public async Task<UserDto> GetAsync(Guid id)
    {
        return await userService.GetAsync(id);
    }

    [HttpDelete]
    public async Task RemoveAsync(Guid id)
    {
        await userService.DeleteAsync(id);
    }
}