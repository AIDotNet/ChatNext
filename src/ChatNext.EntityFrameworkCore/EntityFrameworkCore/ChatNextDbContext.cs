using ChatNext.Data;
using ChatNext.Data.Audit;
using ChatNext.Domain.Chat;
using ChatNext.Domain.Storage;
using ChatNext.Domain.Users;
using ChatNext.EntityFrameworkCore.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore;

public class ChatNextDbContext(DbContextOptions<ChatNextDbContext> options, IUserContext userContext)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<UserOAuthExtension> UserOAuthExtensions { get; set; } = null!;

    public DbSet<FileStorage> FileStorages { get; set; } = null!;

    public DbSet<SessionGroups> SessionGroups { get; set; } = null!;

    public DbSet<Plugins> Plugins { get; set; } = null!;

    public DbSet<Session> Sessions { get; set; } = null!;

    public DbSet<Messages> Messages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ConfigureChatNext()
            .UseLowerCaseNamingConvention()
            .InitializeData();
    }


    private void BeforeSave()
    {
        var now = DateTime.Now;

        foreach (var entry in ChangeTracker.Entries().Where(x =>
                     x.State is EntityState.Added or EntityState.Modified))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    switch (entry.Entity)
                    {
                        case ICreatable<Guid> creatableEntity:
                            if (creatableEntity.CreatedAt == default)
                                creatableEntity.CreatedAt = now;
                            creatableEntity.Creator = userContext.UserId ?? Guid.Empty;
                            break;
                    }

                    break;
                case EntityState.Modified:
                    switch (entry.Entity)
                    {
                        case IUpdatable<Guid> updatableEntity:
                            updatableEntity.UpdatedAt ??= now;
                            updatableEntity.Modifier = userContext.UserId ?? Guid.Empty;
                            break;
                    }

                    break;
            }
        }
    }


    /// <inheritdoc />
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        BeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    /// <inheritdoc />
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new CancellationToken())
    {
        BeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}