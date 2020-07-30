using BAYSOFT.Core.Domain.Entities.StockWallet;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts
{
    public interface IStockWalletDbContextQuery
    {
        public DbSet<Sample> Samples { get; set; }
    }
}
