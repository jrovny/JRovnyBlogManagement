using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace JRovnyBlogManagement.DesktopUI.Features.Posts
{
    public sealed partial class PostsView : UserControl
    {
        public PostsView()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<PostsViewModel>();
        }

        public PostsViewModel ViewModel { get; private set; }

        private async void UserControl_Loading(Microsoft.UI.Xaml.FrameworkElement sender, object args)
        {
            await ViewModel.LoadAsync();
        }
    }
}
