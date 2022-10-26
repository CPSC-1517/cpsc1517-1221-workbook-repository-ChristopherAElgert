using Microsoft.EntityFrameworkCore;
using WestwindSystem.Entities;

namespace WestwindSystem.DAL
{
    internal class WestwindContext: DbContext
    {
        public WestwindContext(DbContextOptions<WestwindContext> options) : base(options)
        {

        }

        public DbSet<BuildVersion> BuildVersions => Set<BuildVersion>();

        public DbSet<Category> Categories => Set<Category>();
    }
}
