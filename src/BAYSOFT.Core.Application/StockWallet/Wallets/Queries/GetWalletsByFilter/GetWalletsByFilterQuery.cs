using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletsByFilter
{
    public class GetWalletsByFilterQuery : ApplicationRequest<Wallet, GetWalletsByFilterQueryResponse>
    {
        public GetWalletsByFilterQuery()
        {
            ConfigKeys(x => x.WalletID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
