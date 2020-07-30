using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Orders;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Orders
{
    public class PutOrderService : DomainService<Order>, IPutOrderService
    {
        private IStockWalletDbContext Context { get; set; }
        public PutOrderService(
            IStockWalletDbContext context,
            OrderValidator entityValidator,
            PutOrderSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Order entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
