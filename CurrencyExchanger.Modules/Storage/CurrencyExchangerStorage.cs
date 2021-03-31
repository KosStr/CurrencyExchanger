using Microsoft.EntityFrameworkCore;

namespace CurrencyExchanger.Modules.Storage
{
    public class CurrencyExchangerStorage : DbContext
    {
        public DbSet<HistoryItem> HistoryItems { get; set; }
        public CurrencyExchangerStorage(DbContextOptions<CurrencyExchangerStorage> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoryItem>().Property(g => g.Date).ValueGeneratedOnAdd();
        }
    }
}