using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Prices;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Prices
{
    public class PostPriceService : DomainService<Price>, IPostPriceService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostPriceService(
            IStockWalletDbContext context,
            PriceValidator entityValidator,
            PostPriceSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Price entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Prices.AddAsync(entity);
        }
    }
}
