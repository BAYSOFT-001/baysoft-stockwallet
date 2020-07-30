using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PatchGrade
{
    public class PatchGradeCommand : ApplicationRequest<Grade, PatchGradeCommandResponse>
    {
        public PatchGradeCommand()
        {
            ConfigKeys(x => x.GradeID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
