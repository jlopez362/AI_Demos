using AI_Demo.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AI_Demo.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAICore(this IServiceCollection services)
    {
        services.AddSingleton<IImageServices, ImageServices>();
        return services;
    }
}