using ChatNext.Data;

namespace ChatNext.Domain.Chat;

/// <summary>
/// 插件
/// </summary>
public class Plugins : Entity<string>
{
    private string _identifier = null!;

    public string Identifier
    {
        get => _identifier;
        set => _identifier = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _type = null!;

    public string Type
    {
        get => _type;
        set => _type = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _avatar = null!;

    public string Avatar
    {
        get => _avatar;
        set => _avatar = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _description = null!;

    public string Description
    {
        get => _description;
        set => _description = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _title = null!;

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string[] _tags = null!;

    public string[] Tags
    {
        get => _tags;
        set => _tags = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _version = null!;

    public string Version
    {
        get => _version;
        set => _version = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _systemRole = null!;

    public string SystemRole
    {
        get => _systemRole;
        set => _systemRole = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _functionName = null!;

    public string FunctionName
    {
        get => _functionName;
        set => _functionName = value ?? throw new ArgumentNullException(nameof(value));
    }
}