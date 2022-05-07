using JRovnyBlogManagement.DesktopUI.Auth;
using JRovnyBlogManagement.DesktopUI.Features.Posts;
using Microsoft.UI.Xaml;

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

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var results = await _apiClient.GetAsync<IEnumerable<PostSummary>>(
        //        new System.Uri("/api/posts", System.UriKind.Relative));
        //}

        private void NavigationControl_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            this.ContentFrame.Navigate(typeof(PostsViewPage), 1);
        }
    }
}
