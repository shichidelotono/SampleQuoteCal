using Microsoft.EntityFrameworkCore;

namespace SampleQuoteApi.Repository
{
    public class QuoteDbContext : DbContext
    {
        public DbSet<CalculateQuoteDbModel> CalculateQuotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=CalculateQuoteDatabase.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<CalculateQuoteDbModel>().ToTable("CalculateQuote", "test");
            modelBuilder.Entity<CalculateQuoteDbModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DateTimeAdded).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
