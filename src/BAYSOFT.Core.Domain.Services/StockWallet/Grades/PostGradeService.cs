using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;
using BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Grades;
using BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Services.StockWallet.Grades
{
    public class PostGradeService : DomainService<Grade>, IPostGradeService
    {
        private IStockWalletDbContext Context { get; set; }
        public PostGradeService(
            IStockWalletDbContext context,
            GradeValidator entityValidator,
            PostGradeSpecificationsValidator domainValidator
        ) : base(entityValidator, domainValidator)
        {
            Context = context;
        }
        public override async Task Run(Grade entity)
        {
            ValidateEntity(entity);

            ValidateDomain(entity);

            await Context.Grades.AddAsync(entity);
        }
    }
}
