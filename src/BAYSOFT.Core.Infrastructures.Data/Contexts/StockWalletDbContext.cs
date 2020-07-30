using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

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
            var defaultDecimalSQLType = "DECIMAL(18,4)";

            modelBuilder.Entity<Wallet>()
                .Property(x => x.Balance)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Order>()
                .Property(x => x.Value)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Price>()
                .Property(x => x.Value)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Stop>()
                .Property(x => x.Gain1)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Stop>()
                .Property(x => x.Gain2)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Stop>()
                .Property(x => x.Loss)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.SectorAndQuality)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.RecommendedWallet)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.Dividend)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.ReturnOnEquity)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.ProfitLast5Years)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.NetMargin)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.Indebtedness)
                .HasColumnType(defaultDecimalSQLType);
            modelBuilder.Entity<Grade>()
                .Property(x => x.Overlap)
                .HasColumnType(defaultDecimalSQLType);

            modelBuilder.Entity<Grade>()
                .HasKey(x => x.StockID);
            modelBuilder.Entity<Grade>()
                .HasOne(x => x.Stock)
                .WithOne(x => x.Grade);
        }
    }
}
