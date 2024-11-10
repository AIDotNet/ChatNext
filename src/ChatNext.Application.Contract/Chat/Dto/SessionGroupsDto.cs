namespace ChatNext.Application.Contract.Chat.Dto;

public class SessionGroupsDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    
    public int Sort { get; set; }
    

    public bool IsDefault { get; set; }
    
    public List<SessionDto> Sessions { get; } = new();
}