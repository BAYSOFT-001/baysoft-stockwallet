using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.DeletePrice
{
    public class DeletePriceCommandResponse : ApplicationResponse<Price>
    {
        public DeletePriceCommandResponse(WrapRequest<Price> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
