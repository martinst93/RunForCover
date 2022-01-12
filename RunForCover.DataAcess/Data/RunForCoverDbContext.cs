using Microsoft.EntityFrameworkCore;
using RunForCover.Models;

namespace RunForCover.Data
{
    public class RunForCoverDbContext : DbContext
    {
        public RunForCoverDbContext(DbContextOptions<RunForCoverDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
