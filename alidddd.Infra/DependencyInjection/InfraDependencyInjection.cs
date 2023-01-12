using alidddd.Application.Auth;
using alidddd.Application.Common.Interfaces;
using alidddd.Application.Common.Interfaces.Reoistories;
using alidddd.Infra.Auth;
using alidddd.Infra.Repositories.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace alidddd.Infra.DependencyInjection;

public static class InfraDependencyInjection
{
    // like db like external reources
    public static IServiceCollection AddInfra(this IServiceCollection service,ConfigurationManager config)
    {
        service.Configure<JwtSettings>(config.GetSection(nameof(JwtSettings)));
        service.AddScoped<IUserRepo,UserRepository>();
        service.AddScoped<IJwtGenerator, JwtGenerator>();
        return service;
    }
}