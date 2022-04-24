using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace JRovnyBlogManagement.DesktopUI
{
    public partial class App : Application
    {
        private Window _window;
        private ServiceProvider _serviceProvider;

        public App()
        {
            InitializeComponent();
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<AuthenticationService>();
            services.AddTransient<MainWindow>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            _window = _serviceProvider.GetService<MainWindow>();
            _window.Activate();
        }
    }
}
