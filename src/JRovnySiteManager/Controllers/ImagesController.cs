using System.Collections.Generic;
using System.Threading.Tasks;
using JRovnySiteManager.Data.EntityFramework;
using JRovnySiteManager.Data.EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JRovnySiteManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _context.Images.AsNoTracking().ToListAsync();
        }
    }
}