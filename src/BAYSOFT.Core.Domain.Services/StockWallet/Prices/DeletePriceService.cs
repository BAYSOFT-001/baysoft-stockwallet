using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Prices;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Prices
{
    public class DeletePriceService : DomainService<Price>,IDeletePriceService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeletePriceService(
            IStockWalletDbContext context,
            PriceValidator entityValidator,
            DeletePriceSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Price entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Prices.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
