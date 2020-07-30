using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradesByFilter
{
    public class GetGradesByFilterQueryResponse : ApplicationResponse<Grade>
    {
        public GetGradesByFilterQueryResponse(WrapRequest<Grade> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
