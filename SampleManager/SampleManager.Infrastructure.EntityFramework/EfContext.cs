using Microsoft.EntityFrameworkCore;
using SampleManager.Core.Models;
using SampleManager.Infrastructure.EntityFramework.Interfaces;

namespace SampleManager.Infrastructure.EntityFramework
{
    public class EfContext : DbContext, IContext
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<User> Users { get; set; }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .Property(s => s.StatusDescription)
                .HasColumnName("Status");
        }
    }
}
