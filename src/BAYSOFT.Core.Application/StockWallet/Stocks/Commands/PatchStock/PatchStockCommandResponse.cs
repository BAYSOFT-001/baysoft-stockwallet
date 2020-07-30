using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PatchStock
{
    public class PatchStockCommandResponse : ApplicationResponse<Stock>
    {
        public PatchStockCommandResponse(WrapRequest<Stock> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
