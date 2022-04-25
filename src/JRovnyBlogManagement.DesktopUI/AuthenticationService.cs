using IdentityModel.OidcClient;
using System.Threading.Tasks;

namespace JRovnyBlogManagement.DesktopUI
{
    public class AuthenticationService
    {
        static OidcClient _oidcClient;
        private string _accessToken;
        readonly Windows.Storage.ApplicationDataContainer _localSettings;
        private const string RefreshTokenKey = "refreshToken";

        public AuthenticationService()
        {
            _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        public async Task<bool> SignInAsync()
        {
            var browser = new SystemBrowser();
            string redirectUri = string.Format($"http://127.0.0.1:{browser.Port}");

            var options = new OidcClientOptions
            {
                Authority = "https://test.accounts.jrovny.com",
                ClientId = "bec79055-1fc3-4990-a8c0-165fec5cd03f",
                RedirectUri = redirectUri,
                Scope = "openid profile JRovnyBlog.Staging.All offline_access",
                FilterClaims = false,
                Browser = browser,
            };

            _oidcClient = new OidcClient(options);

            if (!(await RefreshTokenAsync()))
            {
                var result = await _oidcClient.LoginAsync(new LoginRequest());

                if (result.IsError)
                {
                    return false;
                }
                else
                {
                    _localSettings.Values[RefreshTokenKey] = result.RefreshToken;
                    return true;
                }
            }

            return true;
        }

        private async Task<bool> RefreshTokenAsync()
        {
            string refreshToken = _localSettings.Values[RefreshTokenKey]?.ToString();

            if (string.IsNullOrWhiteSpace(refreshToken))
                return false;

            var result = await _oidcClient.RefreshTokenAsync(refreshToken);

            if (result.IsError)
                return false;

            _accessToken = result.AccessToken;

            return true;
        }
    }
}
