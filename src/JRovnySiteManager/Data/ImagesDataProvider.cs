using System.Collections.Generic;
using System.Threading.Tasks;
using JRovnySiteManager.Data.EntityFramework;
using JRovnySiteManager.Data.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace JRovnySiteManager.Data
{
    public class ImagesDataProvider
    {
        private readonly ApplicationDbContext _context;
        public ImagesDataProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.Images.AsNoTracking().ToListAsync();
        }
    }
}