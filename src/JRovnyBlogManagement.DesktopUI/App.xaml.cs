using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

namespace JRovnyBlogManagement.DesktopUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ServiceCollection services = new();
            ConfigureServices(services);
        }

        private void ConfigureServices(ServiceCollection services)
        {
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow(new AuthenticationService());
            m_window.Activate();
        }

        private Window m_window;
    }
}
