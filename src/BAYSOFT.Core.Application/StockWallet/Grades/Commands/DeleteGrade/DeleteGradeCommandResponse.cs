using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.DeleteGrade
{
    public class DeleteGradeCommandResponse : ApplicationResponse<Grade>
    {
        public DeleteGradeCommandResponse(WrapRequest<Grade> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
