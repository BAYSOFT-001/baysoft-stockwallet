using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PostGrade
{
    public class PostGradeCommand : ApplicationRequest<Grade, PostGradeCommandResponse>
    {
        public PostGradeCommand()
        {
            ConfigKeys(x => x.GradeID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
