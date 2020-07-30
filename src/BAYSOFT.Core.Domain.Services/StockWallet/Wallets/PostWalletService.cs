using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Wallets;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Wallets
{
    public class PostWalletService : DomainService<Wallet>, IPostWalletService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostWalletService(
            IStockWalletDbContext context,
            WalletValidator entityValidator,
            PostWalletSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Wallet entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Wallets.AddAsync(entity);
        }
    }
}
