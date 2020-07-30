using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Stops;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Stops
{
    public class PatchStopService : DomainService<Stop>, IPatchStopService
    {
        private IStockWalletDbContext Context { get; set; }
        public PatchStopService(
            IStockWalletDbContext context,
            StopValidator entityValidator,
            PatchStopSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Stop entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
