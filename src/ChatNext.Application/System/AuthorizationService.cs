using ChatNext.Application.Contract.System;
using ChatNext.Application.Contract.System.Input;
using ChatNext.Application.Contract.Users.Dto;
using ChatNext.Application.Infrastructure;
using ChatNext.Data.Exceptions;
using ChatNext.Domain.Users;
using Gnarly.Data;
using MapsterMapper;

namespace ChatNext.Application.System;

/// <summary>
/// 授权服务
/// </summary>
/// <param name="userRepository"></param>
/// <param name="jwtHelper"></param>
/// <param name="mapper"></param>
public class AuthorizationService(IUserRepository userRepository, JwtHelper jwtHelper, IMapper mapper)
    : IAuthorizationService, IScopeDependency
{
    public async Task<string> TokenAsync(AuthorizationInput input)
    {
        var user = await userRepository.GetByUsernameAsync(input.Username);

        if (user == null)
        {
            throw new UserFriendlyException("未找到用户");
        }

        if (!user.VerifyPassword(input.Password))
        {
            user.UpdateLoginErrorCount();

            await userRepository.UpdateAsync(user);

            throw new UserFriendlyException("密码错误");
        }

        var dto = mapper.Map<UserDto>(user);

        var token = jwtHelper.CreateToken(dto);

        return token;
    }
}