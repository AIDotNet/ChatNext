using ChatNext.Data.Audit;
using ChatNext.Data.Exceptions;
using ChatNext.Data.Helper;
using ChatNext.Domain.Shared;

namespace ChatNext.Domain.Users;

public class User : FullAggregateRoot<Guid>
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
        protected set => _password = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _passwordSalt = null!;

    public string PasswordSalt
    {
        get => _passwordSalt;
        protected set => _passwordSalt = value ?? throw new ArgumentNullException(nameof(value));
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

    private string _latestName;

    public string LatestName
    {
        get => _latestName;
        set => _latestName = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string firstName;

    public string FirstName
    {
        get => firstName;
        set => firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string fullName;

    public string FullName => $"{FirstName} {LatestName}";

    public void SetPassword(string password)
    {
        PasswordSalt = Guid.NewGuid().ToString("N");

        Password = HashHelper.HashPassword(password, PasswordSalt);
    }

    public bool VerifyPassword(string password)
    {
        LastLoginTime = DateTime.Now;

        var hash = HashHelper.HashPassword(password, PasswordSalt);

        if (Password != hash)
        {
            return false;
        }


        return true;
    }

    public void UpdateLoginErrorCount()
    {
        LoginErrorCount++;
        LastLoginErrorTime = DateTime.Now;
    }
}