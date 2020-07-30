using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Orders;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Orders
{
    public class PostOrderService : DomainService<Order>, IPostOrderService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostOrderService(
            IStockWalletDbContext context,
            OrderValidator entityValidator,
            PostOrderSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Order entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Orders.AddAsync(entity);
        }
    }
}
