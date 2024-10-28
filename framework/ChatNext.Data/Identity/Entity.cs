namespace ChatNext.Data;

public class Entity<T>
{
    public T Id { get; set; }
}

public class Entity : Entity<long>
{
}