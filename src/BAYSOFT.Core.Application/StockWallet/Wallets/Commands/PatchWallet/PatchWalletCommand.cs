using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PatchWallet
{
    public class PatchWalletCommand : ApplicationRequest<Wallet, PatchWalletCommandResponse>
    {
        public PatchWalletCommand()
        {
            ConfigKeys(x => x.WalletID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Orders);
            ConfigSuppressedResponseProperties(x => x.Orders);
        }
    }
}
