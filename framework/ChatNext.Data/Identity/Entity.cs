namespace ChatNext.Data;

public class Entity<T>
{
    public required T Id { get; set; }
}

public class Entity : Entity<long>
{
}