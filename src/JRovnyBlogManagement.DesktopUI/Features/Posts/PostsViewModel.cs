using JRovnyBlogManagement.DesktopUI.Auth;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JRovnyBlogManagement.DesktopUI.Features.Posts
{
    public class PostsViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient;

        public PostsViewModel(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task LoadAsync()
        {
            await LoadPostsAsync();
        }

        private async Task LoadPostsAsync()
        {
            var posts = await _apiClient.GetAsync<IEnumerable<PostSummary>>(new Uri("/api/posts", UriKind.Relative));

            foreach (var item in posts)
            {
                Posts.Add(item);
            }
        }

        public ObservableCollection<PostSummary> Posts { get; } = new();
    }
}
