using ChatNext.Data.Audit;

namespace ChatNext.Domain.Chat;

public class SessionGroups : FullAggregateRoot<Guid?>
{
    private string _name = null!;

    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    private int _sort;

    public int Sort
    {
        get => _sort;
        set => _sort = value < 0 ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
    }

    private bool _isDefault;

    public bool IsDefault
    {
        get => _isDefault;
        set => _isDefault = value;
    }
    
}