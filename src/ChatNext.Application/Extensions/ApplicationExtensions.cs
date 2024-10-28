using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace ChatNext.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMapster();
        
        return services;
    }
}