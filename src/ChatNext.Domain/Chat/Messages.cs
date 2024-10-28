using ChatNext.Data.Audit;

namespace ChatNext.Domain.Chat;

public class Messages : FullAggregateRoot<long>
{
    private string _content = null!;

    public string Content
    {
        get => _content;
        set => _content = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _role = null!;

    public string Role
    {
        get => _role;
        set => _role = value ?? throw new ArgumentNullException(nameof(value));
    }

    private long _sessionId;

    public long SessionId
    {
        get => _sessionId;
        set => _sessionId = value;
    }

    private string _fromModel = null!;

    /// <summary>
    /// 消息来源模型
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public string FromModel
    {
        get => _fromModel;
        set => _fromModel = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string[] _files = Array.Empty<string>();


    public string[] Files
    {
        get => _files;
        set => _files = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _plugin = null!;

    public string Plugin
    {
        get => _plugin;
        set => _plugin = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string? _parentId = null!;

    /// <summary>
    /// 父消息id，如果存在则表示一条数据
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public string? ParentId
    {
        get => _parentId;
        set => _parentId = value ?? throw new ArgumentException(nameof(value));
    }
    
}