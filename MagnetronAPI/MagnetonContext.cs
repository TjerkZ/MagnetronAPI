using Microsoft.EntityFrameworkCore;
using MagnetronAPI.Model;

namespace MagnetronAPI
{
    public class MagnetonContext: DbContext
    {
        public MagnetonContext(DbContextOptions<MagnetonContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Prep> Preps { get; set; }
    }
}
