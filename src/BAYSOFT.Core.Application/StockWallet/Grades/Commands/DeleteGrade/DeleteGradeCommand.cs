using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.DeleteGrade
{
    public class DeleteGradeCommand : ApplicationRequest<Grade, DeleteGradeCommandResponse>
    {
        public DeleteGradeCommand()
        {
            ConfigKeys(x => x.GradeID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
