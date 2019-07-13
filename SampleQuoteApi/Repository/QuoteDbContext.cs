using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SampleQuoteApi.Repository
{
    public class QuoteDbContext : DbContext
    {
        public DbSet<QuoteDbModel> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=QuoteDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<QuoteDbModel>().ToTable("Blogs", "test");
            modelBuilder.Entity<QuoteDbModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DateTimeAdded).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
