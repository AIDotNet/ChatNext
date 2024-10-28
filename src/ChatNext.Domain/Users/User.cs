using ChatNext.Data.Audit;
using ChatNext.Domain.Shared;

namespace ChatNext.Domain.Users;

public class User : FullAggregateRoot<Guid?>
{
    private string _username = null!;
    
    public string Username
    {
        get => _username;
        set => _username = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    private string _email = null!;
    
    public string Email
    {
        get => _email;
        set => _email = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    private string _password = null!;
    
    public string Password
    {
        get => _password;
        set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    private string _passwordSalt = null!;
    
    public string PasswordSalt
    {
        get => _passwordSalt;
        set => _passwordSalt = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    private string _avatar = null!;
    
    public string Avatar
    {
        get => _avatar;
        set => _avatar = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    private UserState _state;
    
    public UserState State
    {
        get => _state;
        set => _state = value;
    }
    
    private int _loginErrorCount;
    
    public int LoginErrorCount
    {
        get => _loginErrorCount;
        set => _loginErrorCount = value;
    }
    
    private DateTime? _lastLoginErrorTime;
    
    public DateTime? LastLoginErrorTime
    {
        get => _lastLoginErrorTime;
        set => _lastLoginErrorTime = value;
    }
    
    private DateTime? _lastLoginTime;
    
    public DateTime? LastLoginTime
    {
        get => _lastLoginTime;
        set => _lastLoginTime = value;
    }
}