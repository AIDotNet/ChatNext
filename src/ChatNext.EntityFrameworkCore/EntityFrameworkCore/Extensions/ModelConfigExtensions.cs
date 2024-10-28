using System.Text.Json;
using System.Text.Json.Serialization;
using ChatNext.Domain.Chat;
using ChatNext.Domain.Storage;
using ChatNext.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore.Extensions;

public static class ModelConfigExtensions
{
    private static readonly JsonSerializerOptions JsonSerializerDefaults = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReferenceHandler = ReferenceHandler.Preserve,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    public static ModelBuilder ConfigureChatNext(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(options =>
        {
            options.HasKey(x => x.Id);

            options.Property(x => x.Username).IsRequired();

            options.Property(x => x.Email).IsRequired();

            options.Property(x => x.Password).IsRequired();

            options.Property(x => x.PasswordSalt).IsRequired();

            options.Property(x => x.Avatar).IsRequired();

            options.Property(x => x.State).IsRequired();

            options.HasIndex(x => x.Email);

            options.HasIndex(x => x.Username).IsUnique();

            options.HasIndex(x => x.Email).IsUnique();

            options.HasIndex(x => x.State);
        });

        modelBuilder.Entity<UserOAuthExtension>(options =>
        {
            options.HasKey(x => x.Id);

            options.Property(x => x.UserId).IsRequired();

            options.Property(x => x.Provider).IsRequired();

            options.Property(x => x.ProviderKey).IsRequired();

            options.HasIndex(x => x.UserId);

            options.HasIndex(x => x.Provider);

            options.HasIndex(x => x.ProviderKey);
            
            options.Property(x => x.Extra)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, JsonSerializerDefaults),
                    x => JsonSerializer.Deserialize<Dictionary<string, string>>(x, JsonSerializerDefaults) ?? new()
                );
        });

        modelBuilder.Entity<FileStorage>(options =>
        {
            options.HasKey(x => x.Id);

            options.Property(x => x.Name).IsRequired();

            options.Property(x => x.Data).IsRequired();

            options.Property(x => x.Size).IsRequired();

            options.HasIndex(x => x.Name);

            options.HasIndex(x => x.FileType);

            options.HasIndex(x => x.CreatedAt);
        });

        modelBuilder.Entity<SessionGroups>(options =>
        {
            options.HasKey(x => x.Id);

            options.HasIndex(x => x.Name);

            options.HasIndex(x => x.CreatedAt);
        });

        modelBuilder.Entity<Plugins>(options =>
        {
            options.HasKey(x => x.Id);

            options.Property(x => x.Title).IsRequired();

            options.Property(x => x.Description).IsRequired();

            options.Property(x => x.Version).IsRequired();

            options.Property(x => x.Type).IsRequired();

            options.HasIndex(x => x.Version);

            options.HasIndex(x => x.FunctionName);

            options.HasIndex(x => x.Type);
            
            options.Property(x => x.Tags)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, JsonSerializerDefaults),
                    x => JsonSerializer.Deserialize<string[]>(x, JsonSerializerDefaults) ?? Array.Empty<string>()
                );

        });

        modelBuilder.Entity<Messages>(options =>
        {
            options.HasKey(x => x.Id);

            options.Property(x => x.Content).IsRequired();

            options.Property(x => x.Role).IsRequired();

            options.Property(x => x.SessionId).IsRequired();

            options.HasIndex(x => x.SessionId);

            options.HasIndex(x => x.Role);

            options.HasIndex(x => x.CreatedAt);
            
            options.Property(x => x.Files)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, JsonSerializerDefaults),
                    x => JsonSerializer.Deserialize<string[]>(x, JsonSerializerDefaults) ?? Array.Empty<string>()
                );
        });

        modelBuilder.Entity<Session>(options =>
        {
            options.HasKey(x => x.Id);

            options.Property(x => x.Title).IsRequired();

            options.Property(x => x.CreatedAt).IsRequired();

            options.HasIndex(x => x.Title);

            options.HasIndex(x => x.CreatedAt);

            options.HasIndex(x => x.GroupId);

            options.Property(x => x.Tags)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, JsonSerializerDefaults),
                    x => JsonSerializer.Deserialize<string[]>(x, JsonSerializerDefaults) ?? Array.Empty<string>()
                );

            options.Property(x => x.Config)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, JsonSerializerDefaults),
                    x => JsonSerializer.Deserialize<Dictionary<string, object>>(x, JsonSerializerDefaults) ?? new()
                );

            options.Property(x => x.Plugins)
                .HasConversion(
                    x => JsonSerializer.Serialize(x, JsonSerializerDefaults),
                    x => JsonSerializer.Deserialize<string[]>(x, JsonSerializerDefaults) ?? Array.Empty<string>()
                );
        });

        return modelBuilder;
    }


    public static ModelBuilder UseLowerCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()?.ToLower() ?? entity.Name.ToLower());
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.Name.ToLower());
            }
        }

        return builder;
    }
}