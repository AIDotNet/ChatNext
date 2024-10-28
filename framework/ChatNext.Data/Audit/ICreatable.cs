namespace ChatNext.Data.Audit;

public interface ICreatable<TCreator>
{
    public DateTime CreatedAt { get; set; }

    public TCreator? Creator { get; set; }
}