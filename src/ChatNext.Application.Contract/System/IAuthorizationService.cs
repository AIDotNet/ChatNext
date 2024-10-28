using ChatNext.Application.Contract.System.Input;

namespace ChatNext.Application.Contract.System;

public interface IAuthorizationService
{
    /// <summary>
    /// Token授权
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<string> TokenAsync(AuthorizationInput input);
    
    
}