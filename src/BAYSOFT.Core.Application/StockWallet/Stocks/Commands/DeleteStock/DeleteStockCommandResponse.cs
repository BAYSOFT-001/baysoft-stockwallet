using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandResponse : ApplicationResponse<Stock>
    {
        public DeleteStockCommandResponse(WrapRequest<Stock> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
