using IdentityModel.OidcClient;
using System.Threading.Tasks;

namespace JRovnyBlogManagement.DesktopUI
{
    public class AuthenticationService
    {
        static string _authority = "https://test.accounts.jrovny.com";
        static OidcClient _oidcClient;

        public async Task<LoginResult> Login()
        {
            var browser = new SystemBrowser();
            string redirectUri = string.Format($"http://127.0.0.1:{browser.Port}");

            var options = new OidcClientOptions
            {
                Authority = _authority,
                ClientId = "bec79055-1fc3-4990-a8c0-165fec5cd03f",
                RedirectUri = redirectUri,
                Scope = "openid profile JRovnyBlog.Staging.All offline_access",
                FilterClaims = false,
                Browser = browser,
            };

            _oidcClient = new OidcClient(options);
            return await _oidcClient.LoginAsync(new LoginRequest());
        }
    }
}
