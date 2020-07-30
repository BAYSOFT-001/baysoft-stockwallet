using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PutWallet
{
    public class PutWalletCommand : ApplicationRequest<Wallet, PutWalletCommandResponse>
    {
        public PutWalletCommand()
        {
            ConfigKeys(x => x.WalletID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
