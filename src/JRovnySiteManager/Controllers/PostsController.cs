using System.Collections.Generic;
using System.Threading.Tasks;
using JRovnySiteManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JRovnySiteManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var post = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }
    }
}
