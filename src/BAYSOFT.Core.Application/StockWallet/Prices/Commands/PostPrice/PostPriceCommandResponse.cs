using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PostPrice
{
    public class PostPriceCommandResponse : ApplicationResponse<Price>
    {
        public PostPriceCommandResponse(WrapRequest<Price> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
