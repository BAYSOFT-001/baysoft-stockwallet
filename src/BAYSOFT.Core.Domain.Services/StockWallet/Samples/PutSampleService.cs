using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.EntityValidations.StockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Samples
{
    public class PutSampleService : DomainService<Sample>, IPutSampleService
    {
        private IStockWalletDbContext Context { get; set; }
        public PutSampleService(
            IStockWalletDbContext context,
            SampleValidator entityValidator,
            PutSampleSpecificationsValidator domainValidator
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
