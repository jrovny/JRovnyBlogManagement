using JRovnyBlogManagement.DesktopUI.Auth;
using JRovnyBlogManagement.DesktopUI.Events;
using JRovnyBlogManagement.DesktopUI.Features.Posts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using System;
using System.Net.Http.Headers;

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
            Services = ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private IServiceProvider ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<AuthenticationService>();
            services.AddTransient<AccessTokenHandler>();
            services.AddHttpClient<ApiClient>(options =>
            {
                options.BaseAddress = new Uri("https://test.portal.jrovny.com");
                options.DefaultRequestHeaders.Clear();
                options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                options.DefaultRequestHeaders.UserAgent.ParseAdd("BlogManagementDesktopAppStaging");

            }).AddHttpMessageHandler<AccessTokenHandler>();
            services.AddTransient<SplashScreenView>();
            services.AddTransient<MainWindow>();
            services.AddTransient<PostsView>();

            return services.BuildServiceProvider();
        }

        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get;  }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            var splashScreen = _serviceProvider.GetRequiredService<SplashScreenView>();
            splashScreen.Activate();
            
            WeakReferenceMessenger.Default.Register<UserSignedInEvent>(this, (r, m) =>
            {
                _window = _serviceProvider.GetRequiredService<MainWindow>();
                _window.Activate();
                splashScreen.Close();
            });
            
            await splashScreen.SignInAsync();
        }
    }
}
