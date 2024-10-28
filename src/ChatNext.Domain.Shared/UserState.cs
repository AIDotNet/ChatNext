namespace ChatNext.Domain.Shared;

public enum UserState : byte
{
    /// <summary>
    /// 启用
    /// </summary>
    Enabled = 1,

    /// <summary>
    /// 禁用
    /// </summary>
    Disabled = 2
}