using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Grades;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Grades
{
    public class DeleteGradeService : DomainService<Grade>,IDeleteGradeService
    {
        private IStockWalletDbContext Context { get; set; }
        public DeleteGradeService(
            IStockWalletDbContext context,
            GradeValidator entityValidator,
            DeleteGradeSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }

        public override Task Run(Grade entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            Context.Grades.Remove(entity);

            return Task.CompletedTask;
        }
    }
}
