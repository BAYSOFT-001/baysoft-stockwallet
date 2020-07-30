using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStockByID
{
    public class GetStockByIDQueryResponse : ApplicationResponse<Stock>
    {
        public GetStockByIDQueryResponse(WrapRequest<Stock> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
