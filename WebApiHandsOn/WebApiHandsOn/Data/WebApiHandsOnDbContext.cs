using Microsoft.EntityFrameworkCore;
using WebApiHandsOn.Entities;

namespace WebApiHandsOn.Data
{
    public class WebApiHandsOnDbContext : DbContext
    {
        private readonly DbContextOptions _context;
        public WebApiHandsOnDbContext(DbContextOptions<WebApiHandsOnDbContext> options) : base(options)
        {
            _context = options;
        }

        public DbSet<User> Users { get; set; }
    }
}
