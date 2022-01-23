using System.Collections.Generic;
using System.Threading.Tasks;
using JRovnySiteManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace JRovnySiteManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await Task.FromResult(new List<Post> { new Post { PostId = 1, Title = "Test", Slug = "test" } });
        }
    }
}
