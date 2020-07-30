using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Stops;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Stops
{
    public class PostStopService : DomainService<Stop>, IPostStopService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostStopService(
            IStockWalletDbContext context,
            StopValidator entityValidator,
            PostStopSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Stop entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Stops.AddAsync(entity);
        }
    }
}
