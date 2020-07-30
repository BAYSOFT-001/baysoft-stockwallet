using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.DeleteWallet
{
    public class DeleteWalletCommand : ApplicationRequest<Wallet, DeleteWalletCommandResponse>
    {
        public DeleteWalletCommand()
        {
            ConfigKeys(x => x.WalletID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
