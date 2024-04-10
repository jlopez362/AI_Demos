using AI_Demo.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AI_Demo.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAICore(this IServiceCollection services, Action<HuggingFaceOptions> options)
    {
        services.Configure(options);
        services.AddSingleton<ITextServices, TextServices>();
        services.AddSingleton<IImageServices, ImageServices>();
        return services;
    }
}