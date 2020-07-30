using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PostWallet
{
    public class PostWalletCommand : ApplicationRequest<Wallet, PostWalletCommandResponse>
    {
        public PostWalletCommand()
        {
            ConfigKeys(x => x.WalletID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
