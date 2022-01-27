using JRovnySiteManager.Data.EntityFramework;
using JRovnySiteManager.Data.EntityFramework.Models;
using JRovnySiteManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JRovnySiteManager.Data
{
    public class PostsDataProvider
    {
        private readonly ApplicationDbContext _context;
        public PostsDataProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PostSummary>> GetAllPostsAsync()
        {
            return await _context
                .Posts
                .AsNoTracking()
                .Select(p => new PostSummary
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Slug = p.Slug,
                    CreatedDate = p.CreatedDate
                })
                .ToListAsync();
        }


        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.PostId == id);
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }

    }
}