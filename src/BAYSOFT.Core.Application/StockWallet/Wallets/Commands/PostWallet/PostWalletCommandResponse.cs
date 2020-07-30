using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PostWallet
{
    public class PostWalletCommandResponse : ApplicationResponse<Wallet>
    {
        public PostWalletCommandResponse(WrapRequest<Wallet> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
