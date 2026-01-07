using Microsoft.EntityFrameworkCore;

namespace Minecraft.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Minecraft.Models.User> Users { get; set; }
    }
}