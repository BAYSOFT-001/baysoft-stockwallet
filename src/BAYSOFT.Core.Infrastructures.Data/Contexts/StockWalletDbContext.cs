using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Infrastructures.Data.Contexts
{
    public class StockWalletDbContext : DbContext, IStockWalletDbContext
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<SubSector> SubSectors { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected StockWalletDbContext()
        {
            Database.Migrate();
        }

        public StockWalletDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>()
                .HasKey(x => x.StockID);
            modelBuilder.Entity<Grade>()
                .HasOne(x => x.Stock)
                .WithOne(x => x.Grade);
        }
    }
}
