using JRovnySiteManager.Data.EntityFramework;
using JRovnySiteManager.Data.EntityFramework.Models;
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

        public async Task<List<Data.Models.PostSummary>> GetAllPostsAsync()
        {
            return await _context
                .Posts
                .AsNoTracking()
                .Select(p => new Data.Models.PostSummary
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Slug = p.Slug,
                    CreatedDate = p.CreatedDate
                })
                .OrderByDescending(p => p.PostId)
                .ToListAsync();
        }


        public async Task<Data.Models.PostDetailView> GetByIdAsync(int id)
        {
            return await _context
                .Posts
                .AsNoTracking()
                .Include(p => p.Image)
                .DefaultIfEmpty()
                .Where(p => p.PostId == id)
                .Select(p => new Data.Models.PostDetailView
                {
                    PostId = p.PostId,
                    Title = p.Title,
                    Slug = p.Slug,
                    Content = p.Content,
                    CreatedDate = p.CreatedDate,
                    Image = p.Image.Url,
                    Published = p.Published,
                    PublishedDate = p.PublishedDate
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Post> UpdateAsync(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();

            return post;
        }
    }
}