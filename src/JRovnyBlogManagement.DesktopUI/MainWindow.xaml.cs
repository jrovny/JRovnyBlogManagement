using Microsoft.UI.Xaml;

namespace JRovnyBlogManagement.DesktopUI
{
    public sealed partial class MainWindow : Window
    {
        private readonly AuthenticationService _authenticationService;

        public MainWindow(AuthenticationService authenticationService)
        {
            InitializeComponent();
            _authenticationService = authenticationService;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _authenticationService.Login();
        }
    }
}
