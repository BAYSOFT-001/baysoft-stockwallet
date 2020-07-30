using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Wallets;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Wallets
{
    public class PatchWalletService : DomainService<Wallet>, IPatchWalletService
    {
        private IStockWalletDbContext Context { get; set; }
        public PatchWalletService(
            IStockWalletDbContext context,
            WalletValidator entityValidator,
            PatchWalletSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Wallet entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
