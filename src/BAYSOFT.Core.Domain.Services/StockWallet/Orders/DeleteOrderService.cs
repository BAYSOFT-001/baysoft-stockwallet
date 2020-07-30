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
    public class DeleteOrderService : DomainService<Order>,IDeleteOrderService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeleteOrderService(
            IStockWalletDbContext context,
            OrderValidator entityValidator,
            DeleteOrderSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Order entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Orders.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
