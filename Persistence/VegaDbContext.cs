using Microsoft.EntityFrameworkCore;
using VEGA.Models;

namespace VEGA.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Make> Makes{get;set;}
        public DbSet<Feature> Features{get;set;}
    }
}