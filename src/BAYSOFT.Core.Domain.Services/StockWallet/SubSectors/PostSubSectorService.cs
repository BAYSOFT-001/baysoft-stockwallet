using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.SubSectors
{
    public class PostSubSectorService : DomainService<SubSector>, IPostSubSectorService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostSubSectorService(
            IStockWalletDbContext context,
            SubSectorValidator entityValidator,
            PostSubSectorSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(SubSector entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.SubSectors.AddAsync(entity);
        }
    }
}
