using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopsByFilter
{
    public class GetStopsByFilterQueryResponse : ApplicationResponse<Stop>
    {
        public GetStopsByFilterQueryResponse(WrapRequest<Stop> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
