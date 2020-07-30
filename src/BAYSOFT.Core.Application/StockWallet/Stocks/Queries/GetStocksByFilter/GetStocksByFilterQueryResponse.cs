using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStocksByFilter
{
    public class GetStocksByFilterQueryResponse : ApplicationResponse<Stock>
    {
        public GetStocksByFilterQueryResponse(WrapRequest<Stock> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
