using me_blazings.Providers;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.Kiota.Abstractions.Authentication;

namespace me_blazings.Extensions;

public static class GraphClientExtensions
{
    public static IServerSideBlazorBuilder AddMicrosoftGraphClient(this IServerSideBlazorBuilder builder)
    {
        builder.Services.AddMicrosoftGraphClient();
        return builder;
    }

    public static IServiceCollection AddMicrosoftGraphClient(this IServiceCollection services)
    {
        services.AddScoped(serviceProvider =>
        {
            var tokenAcquisition = serviceProvider.GetRequiredService<ITokenAcquisition>();
            var authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider(tokenAcquisition));
            var graphServiceClient = new GraphServiceClient(authenticationProvider);
            return graphServiceClient;
        });

        return services;
    }
}