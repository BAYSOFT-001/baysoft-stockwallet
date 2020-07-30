using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PutWallet
{
    public class PutWalletCommandResponse : ApplicationResponse<Wallet>
    {
        public PutWalletCommandResponse(WrapRequest<Wallet> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
