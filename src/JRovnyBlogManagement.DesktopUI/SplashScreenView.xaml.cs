using JRovnyBlogManagement.DesktopUI.Events;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;

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

        private async void SignIn_Click(object sender, RoutedEventArgs e)
        {
            var result = await _authenticationService.Login();

            if (result is not null)
            {
                WeakReferenceMessenger.Default.Send(new UserSignedInEvent());
            }
        }
    }
}
