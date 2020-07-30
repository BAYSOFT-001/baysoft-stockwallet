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
    public class DeleteStopService : DomainService<Stop>,IDeleteStopService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeleteStopService(
            IStockWalletDbContext context,
            StopValidator entityValidator,
            DeleteStopSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Stop entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Stops.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
