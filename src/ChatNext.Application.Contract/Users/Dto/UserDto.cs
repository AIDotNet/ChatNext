using ChatNext.Data.Audit;
using ChatNext.Domain.Shared;

namespace ChatNext.Application.Contract.Users.Dto;

public class UserDto : FullAggregateRoot<Guid>
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Avatar { get; set; } = null!;

    public UserState State { get; set; }

    public int LoginErrorCount { get; set; }

    public DateTime? LastLoginErrorTime { get; set; }

    public DateTime? LastLoginTime { get; set; }
}