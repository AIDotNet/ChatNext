using ChatNext.Domain.Users;
using ChatNext.EntityFrameworkCore.EntityFrameworkCore.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChatNext.EntityFrameworkCore.EntityFrameworkCore.Extensions;

public static class EntityFrameworkCoreExtensions
{
    public static IServiceCollection AddEntityFrameworkCore(this IServiceCollection services,
        Action<DbContextOptionsBuilder>? optionsAction = null)
    {
        services.AddDbContext<ChatNextDbContext>(optionsAction);

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}