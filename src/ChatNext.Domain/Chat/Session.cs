using ChatNext.Data.Audit;

namespace ChatNext.Domain.Chat;

public class Session : FullAggregateRoot<long>
{
    private Guid _groupId;

    public Guid GroupId
    {
        get => _groupId;
        set => _groupId = value;
    }

    private bool _pinned;

    public bool Pinned
    {
        get => _pinned;
        set => _pinned = value;
    }

    public string? Type { get; set; }

    private Dictionary<string, object> _config = new();

    public Dictionary<string, object> Config
    {
        get => _config;
        set => _config = value ?? throw new ArgumentNullException(nameof(value));
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

    private string _title;

    public string Title
    {
        get => _title;
        set => _title = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string[] _tags = Array.Empty<string>();

    public string[] Tags
    {
        get => _tags;
        set => _tags = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _model = null!;

    public string Model
    {
        get => _model;
        set => _model = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _provider = null!;

    public string Provider
    {
        get => _provider;
        set => _provider = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string systemRole = null!;

    public string SystemRole
    {
        get => systemRole;
        set => systemRole = value ?? throw new ArgumentNullException(nameof(value));
    }

    private float _top_p = 1.0f;

    public float TopP
    {
        get => _top_p;
        set => _top_p = value;
    }

    private float _temperature = 1.0f;

    /// <summary>
    /// Temperature to be applied to the model.
    /// </summary>
    public float Temperature
    {
        get => _temperature;
        set => _temperature = value;
    }

    private float _presence_penalty = 0;

    /// <summary>
    /// Presence penalty to be applied to the context tokens.
    /// </summary>
    public float PresencePenalty
    {
        get => _presence_penalty;
        set => _presence_penalty = value;
    }
    
    /// 限制历史消息数量
    private int _historyLimit = 0;
    
    public int HistoryLimit
    {
        get => _historyLimit;
        set => _historyLimit = value;
    }
    
    private string[] _plugins = Array.Empty<string>();
    
    /// <summary>
    /// 插件列表
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public string[] Plugins
    {
        get => _plugins;
        set => _plugins = value ?? throw new ArgumentNullException(nameof(value));
    }
}