using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Infrastructures.Data.Contexts
{
    public class StockWalletDbContext : DbContext, IStockWalletDbContext
    {
        public DbSet<Sample> Samples { get; set; }

        protected StockWalletDbContext()
        {
            Database.Migrate();
        }

        public StockWalletDbContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
