using ChatNext.Data.Audit;

namespace ChatNext.Domain.Storage;

public class Files : FullAggregateRoot<long>
{
    private string _name = null!;

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _fileType = null!;

    public string FileType
    {
        get => _fileType;
        set => _fileType = value ?? throw new ArgumentNullException(nameof(value));
    }

    private long _size;

    public long Size
    {
        get => _size;
        set => _size = value;
    }

    private string _saveMode = null!;

    public string SaveMode
    {
        get => _saveMode;
        set => _saveMode = value ?? throw new ArgumentNullException(nameof(value));
    }

    private string _data = null!;

    public string Data
    {
        get => _data;
        set => _data = value ?? throw new ArgumentNullException(nameof(value));
    }
}