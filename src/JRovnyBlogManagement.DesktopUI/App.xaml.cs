using JRovnyBlogManagement.DesktopUI.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
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
            services.AddTransient<SplashScreenView>();
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            var splashScreen = _serviceProvider.GetRequiredService<SplashScreenView>();
            splashScreen.Activate();
            
            WeakReferenceMessenger.Default.Register<UserSignedInEvent>(this, (r, m) =>
            {
                _window = new MainWindow();
                _window.Activate();
                splashScreen.Close();
            });
            
            await splashScreen.SignInAsync();
        }
    }
}
