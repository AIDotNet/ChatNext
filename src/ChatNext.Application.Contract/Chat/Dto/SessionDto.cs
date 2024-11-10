namespace ChatNext.Application.Contract.Chat.Dto;

public class SessionDto
{
    public long Id { get; set; }
    
    public Guid GroupId { get; set; }

    
    public bool Pinned { get; set; }
    

    public string? Type { get; set; }

    public Dictionary<string, object> Config { get; set; }


    public string Avatar { get; set; }

    public string Description { get; set; }

    public string Title { get; set; }

    public string[] Tags { get; set; }

    public string Model { get; set; }


    public string Provider { get; set; }
 
    public string SystemRole { get; set; }
 
    public float TopP { get; set; } = 0.9f;
 

    /// <summary>
    /// Temperature to be applied to the model.
    /// </summary>
    public float Temperature { get; set; } = 0.6f;
 

    /// <summary>
    /// Presence penalty to be applied to the context tokens.
    /// </summary>
    public float PresencePenalty { get; set; } = 0.0f;
    
    public int HistoryLimit { get; set; } = 0;
     
    /// <summary>
    /// 插件列表
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public string[] Plugins { get; set; } = Array.Empty<string>();
}