namespace ChatNext.Data.Audit;

public interface IUpdatable<TModifier>
{
    public DateTime? UpdatedAt { get; set; }

    public TModifier? Modifier { get; set; }
}