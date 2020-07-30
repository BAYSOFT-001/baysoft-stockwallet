using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PatchPrice
{
    public class PatchPriceCommandResponse : ApplicationResponse<Price>
    {
        public PatchPriceCommandResponse(WrapRequest<Price> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
