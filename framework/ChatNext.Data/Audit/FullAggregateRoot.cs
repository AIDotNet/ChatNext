namespace ChatNext.Data.Audit;

public abstract class FullAggregateRoot<TKey> : Entity<TKey>, ICreatable<Guid?>, IUpdatable<Guid?>
{
    public DateTime CreatedAt { get; set; }
    
    public Guid? Creator { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    public Guid? Modifier { get; set; }
}