using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Sectors
{
    public class PostSectorService : DomainService<Sector>, IPostSectorService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostSectorService(
            IStockWalletDbContext context,
            SectorValidator entityValidator,
            PostSectorSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Sector entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Sectors.AddAsync(entity);
        }
    }
}
