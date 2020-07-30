using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.SubSectors;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.SubSectors
{
    public class PutSubSectorService : DomainService<SubSector>, IPutSubSectorService
    {
        private IStockWalletDbContext Context { get; set; }
        public PutSubSectorService(
            IStockWalletDbContext context,
            SubSectorValidator entityValidator,
            PutSubSectorSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(SubSector entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            return Task.CompletedTask;
        }
    }
}
