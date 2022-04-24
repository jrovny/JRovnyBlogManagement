using IdentityModel.OidcClient;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace JRovnyBlogManagement.DesktopUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        static string _authority = "https://test.accounts.jrovny.com"; // "https://demo.duendesoftware.com";
        //static string _api = "https://demo.duendesoftware.com/api/test";
        static OidcClient _oidcClient;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private static async Task Login()
        {
            // create a redirect URI using an available port on the loopback address.
            // requires the OP to allow random ports on 127.0.0.1 - otherwise set a static port
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
            var result = await _oidcClient.LoginAsync(new LoginRequest());

            //ShowResult(result);
            //await NextSteps(result);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Login();
        }
    }
}
