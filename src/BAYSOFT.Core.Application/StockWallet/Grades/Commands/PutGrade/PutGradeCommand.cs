using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PutGrade
{
    public class PutGradeCommand : ApplicationRequest<Grade, PutGradeCommandResponse>
    {
        public PutGradeCommand()
        {
            ConfigKeys(x => x.StockID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
