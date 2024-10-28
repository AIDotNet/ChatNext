namespace ChatNext.Data;

public interface IUserContext
{
    Guid? UserId { get; }
    
    bool IsAuthenticated { get; }
}