using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PostGrade
{
    public class PostGradeCommandResponse : ApplicationResponse<Grade>
    {
        public PostGradeCommandResponse(WrapRequest<Grade> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
