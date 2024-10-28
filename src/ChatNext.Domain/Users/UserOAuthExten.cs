using ChatNext.Data;

namespace ChatNext.Domain.Users;

public class UserOAuthExtension : Entity<long>
{
    private string _userId = null!;

    /// <summary>
    /// 绑定的用户Id
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public string UserId
    {
        get => _userId;
        set => _userId = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _provider = null!;

    /// <summary>
    /// 提供商
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public string Provider
    {
        get => _provider;
        set => _provider = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _providerKey = null!;

    /// <summary>
    /// 第三方登录的Key
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public string ProviderKey
    {
        get => _providerKey;
        set => _providerKey = value ?? throw new ArgumentNullException(nameof(value));
    }
}