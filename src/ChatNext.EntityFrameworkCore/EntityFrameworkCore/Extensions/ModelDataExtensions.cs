using ChatNext.Domain.Chat;
using ChatNext.Domain.Shared;
using ChatNext.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore.Extensions;

public static class ModelDataExtensions
{
    public static ModelBuilder InitializeData(this ModelBuilder modelBuilder)
    {
        var admin = new User()
        {
            Id = Guid.NewGuid(),
            Username = "admin",
            Email = "239573049@qq.com",
            Avatar = "https://chat-preview.lobehub.com/icons/icon-192x192.png",
            State = UserState.Enabled,
            CreatedAt = DateTime.Now
        };

        admin.SetPassword("Aa123456.");

        modelBuilder.Entity<User>().HasData(admin);

        var group = new SessionGroups()
        {
            Id = Guid.NewGuid(),
            Name = "Default",
            CreatedAt = DateTime.Now,
            Creator = admin.Id,
        };

        modelBuilder.Entity<SessionGroups>().HasData(group);

        var session = new Session()
        {
            Title = "Default",
            GroupId = group.Id,
            CreatedAt = DateTime.Now,
            Creator = admin.Id,
            SystemRole = string.Empty,
            Avatar = "https://registry.npmmirror.com/@lobehub/fluent-emoji-3d/1.1.0/files/assets/1f92f.webp",
            Pinned = false,
            HistoryLimit = -1,
        };

        modelBuilder.Entity<Session>().HasData(session);
        
        return modelBuilder;
    }
}