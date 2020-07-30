using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Stocks
{
    public class PostStockService : DomainService<Stock>, IPostStockService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostStockService(
            IStockWalletDbContext context,
            StockValidator entityValidator,
            PostStockSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Stock entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Stocks.AddAsync(entity);
        }
    }
}
