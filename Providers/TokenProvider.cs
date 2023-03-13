using Microsoft.Identity.Web;
using Microsoft.Kiota.Abstractions.Authentication;

namespace me_blazings.Providers;
public class TokenProvider : IAccessTokenProvider
{
    private readonly ITokenAcquisition _tokenAcquisition;
    public TokenProvider(ITokenAcquisition tokenAcquisition)
    {
        _tokenAcquisition = tokenAcquisition;
    }

    public async Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object> additionalAuthenticationContext = default,
        CancellationToken cancellationToken = default)
    {
        var token = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { "User.Read" });
        return token;
    }

    public AllowedHostsValidator AllowedHostsValidator { get; }
}