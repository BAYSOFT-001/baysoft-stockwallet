using BAYSOFT.Core.Domain.Entities.StockWallet;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface IStockWalletDbContextQuery
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
    }
}
