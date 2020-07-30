using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopByID
{
    public class GetStopByIDQueryResponse : ApplicationResponse<Stop>
    {
        public GetStopByIDQueryResponse(WrapRequest<Stop> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
