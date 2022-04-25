using JRovnyBlogManagement.DesktopUI.Auth;
using Microsoft.UI.Xaml;
using System.Collections.Generic;

namespace JRovnyBlogManagement.DesktopUI
{
    public sealed partial class MainWindow : Window
    {
        private readonly ApiClient _apiClient;

        public MainWindow(ApiClient apiClient)
        {
            InitializeComponent();
            this._apiClient = apiClient;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var results = await _apiClient.GetAsync<IEnumerable<PostSummary>>(
                new System.Uri("/api/posts", System.UriKind.Relative));
        }
    }
}
