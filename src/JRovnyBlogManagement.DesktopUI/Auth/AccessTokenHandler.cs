using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace JRovnyBlogManagement.DesktopUI.Auth
{
    public class AccessTokenHandler : DelegatingHandler
    {
        private readonly AuthenticationService _authenticationService;

        public AccessTokenHandler(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Authorization =
                new AuthenticationHeaderValue("bearer", await _authenticationService.AccessToken());

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
