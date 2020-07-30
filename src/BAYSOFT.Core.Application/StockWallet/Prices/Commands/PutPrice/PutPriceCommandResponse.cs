using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PutPrice
{
    public class PutPriceCommandResponse : ApplicationResponse<Price>
    {
        public PutPriceCommandResponse(WrapRequest<Price> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
