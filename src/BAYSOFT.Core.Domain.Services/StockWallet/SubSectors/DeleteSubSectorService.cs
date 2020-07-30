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
    public class DeleteSubSectorService : DomainService<SubSector>,IDeleteSubSectorService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeleteSubSectorService(
            IStockWalletDbContext context,
            SubSectorValidator entityValidator,
            DeleteSubSectorSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(SubSector entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.SubSectors.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
