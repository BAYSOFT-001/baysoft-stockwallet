using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradeByID
{
    public class GetGradeByIDQueryResponse : ApplicationResponse<Grade>
    {
        public GetGradeByIDQueryResponse(WrapRequest<Grade> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
