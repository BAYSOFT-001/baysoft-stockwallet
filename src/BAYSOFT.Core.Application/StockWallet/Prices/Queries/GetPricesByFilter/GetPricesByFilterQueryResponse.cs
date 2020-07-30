using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPricesByFilter
{
    public class GetPricesByFilterQueryResponse : ApplicationResponse<Price>
    {
        public GetPricesByFilterQueryResponse(WrapRequest<Price> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
