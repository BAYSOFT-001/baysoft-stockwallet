using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPriceByID
{
    public class GetPriceByIDQueryResponse : ApplicationResponse<Price>
    {
        public GetPriceByIDQueryResponse(WrapRequest<Price> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
