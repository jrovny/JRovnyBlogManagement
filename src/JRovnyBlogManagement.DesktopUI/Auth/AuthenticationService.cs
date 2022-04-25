using IdentityModel.OidcClient;
using System;
using System.Threading.Tasks;

namespace JRovnyBlogManagement.DesktopUI.Auth
{
    public class AuthenticationService
    {
        static OidcClient _oidcClient;
        private string _accessToken;
        private DateTimeOffset _accessTokenExpiration;
        readonly Windows.Storage.ApplicationDataContainer _localSettings;
        private const string RefreshTokenKey = "refreshToken";

        public AuthenticationService()
        {
            SetOidcClient();
            _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        }

        public async Task<bool> SignInAsync()
        {
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
                    _accessToken = result.AccessToken;
                    _accessTokenExpiration = result.AccessTokenExpiration;

                    return true;
                }
            }

            return true;
        }

        private static void SetOidcClient()
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
            _accessTokenExpiration = result.AccessTokenExpiration;

            return true;
        }

        public async Task<string> AccessToken()
        {
            // Check access token expiration here
            if (AccessTokenExpired())
            {
                if (!(await SignInAsync()))
                {
                    throw new Exception("Unable to get access token");
                }
            }

            return _accessToken;
        }

        private bool AccessTokenExpired()
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
            {
                return true;
            }

            return _accessTokenExpiration.Subtract(DateTime.UtcNow).TotalMilliseconds < 5000;
        }
    }
}
