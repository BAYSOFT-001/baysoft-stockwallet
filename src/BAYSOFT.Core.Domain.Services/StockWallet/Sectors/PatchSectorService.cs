using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Sectors;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Sectors
{
    public class PatchSectorService : DomainService<Sector>, IPatchSectorService
    {
        private IStockWalletDbContext Context { get; set; }
        public PatchSectorService(
            IStockWalletDbContext context,
            SectorValidator entityValidator,
            PatchSectorSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Sector entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
