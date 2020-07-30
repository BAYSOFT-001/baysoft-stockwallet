using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Samples;
using BAYSOFT.Core.Domain.Validations.EntityValidations.StockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Samples
{
    public class DeleteSampleService : DomainService<Sample>,IDeleteSampleService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeleteSampleService(
            IStockWalletDbContext context,
            SampleValidator entityValidator,
            DeleteSampleSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Sample entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Samples.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
