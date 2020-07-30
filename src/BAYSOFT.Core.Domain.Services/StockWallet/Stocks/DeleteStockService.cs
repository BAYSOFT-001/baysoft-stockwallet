using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Stocks;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Stocks
{
    public class DeleteStockService : DomainService<Stock>,IDeleteStockService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeleteStockService(
            IStockWalletDbContext context,
            StockValidator entityValidator,
            DeleteStockSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Stock entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Stocks.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
