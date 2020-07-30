using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.DeleteWallet
{
    public class DeleteWalletCommandResponse : ApplicationResponse<Wallet>
    {
        public DeleteWalletCommandResponse(WrapRequest<Wallet> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
