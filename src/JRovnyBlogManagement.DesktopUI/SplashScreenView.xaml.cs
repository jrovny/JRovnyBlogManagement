using JRovnyBlogManagement.DesktopUI.Auth;
using JRovnyBlogManagement.DesktopUI.Events;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace JRovnyBlogManagement.DesktopUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashScreenView : Window
    {
        private readonly AuthenticationService _authenticationService;

        public SplashScreenView(AuthenticationService authenticationService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
        }

        public async Task SignInAsync()
        {
            if (await _authenticationService.SignInAsync())
            {
                WeakReferenceMessenger.Default.Send(new UserSignedInEvent());
            }
            else
            {
                this.Close();
            }
        }
    }
}
