using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PostStock
{
    public class PostStockCommandResponse : ApplicationResponse<Stock>
    {
        public PostStockCommandResponse(WrapRequest<Stock> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
