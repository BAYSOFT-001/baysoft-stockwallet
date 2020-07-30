using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PatchGrade
{
    public class PatchGradeCommandResponse : ApplicationResponse<Grade>
    {
        public PatchGradeCommandResponse(WrapRequest<Grade> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
