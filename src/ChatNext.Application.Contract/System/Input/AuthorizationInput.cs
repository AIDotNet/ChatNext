namespace ChatNext.Application.Contract.System.Input;

/// <summary>
/// 授权输入
/// </summary>
/// <param name="Username"></param>
/// <param name="Password"></param>
public record AuthorizationInput(string Username, string Password);