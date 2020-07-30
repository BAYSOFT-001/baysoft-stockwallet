using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.EntityValidations.StockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Samples
{
    public class PatchSampleService : DomainService<Sample>, IPatchSampleService
    {
        private IStockWalletDbContext Context { get; set; }
        public PatchSampleService(
            IStockWalletDbContext context,
            SampleValidator entityValidator,
            PatchSampleSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Sample entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
