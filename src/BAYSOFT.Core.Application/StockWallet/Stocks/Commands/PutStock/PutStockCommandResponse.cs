using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PutStock
{
    public class PutStockCommandResponse : ApplicationResponse<Stock>
    {
        public PutStockCommandResponse(WrapRequest<Stock> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
