using alidddd.Application.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace alidddd.Application;

public static class AppDependencyInjection
{
    public static IServiceCollection AddApp(this IServiceCollection service)
    {
        service.AddScoped<IAuthService,AuthService>();
        return service;
    }
}