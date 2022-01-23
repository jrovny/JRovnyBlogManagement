using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JRovnySiteManager
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(_configuration.GetConnectionString("Default"));
        }
    }
}