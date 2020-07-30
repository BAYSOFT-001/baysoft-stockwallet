using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletByID
{
    public class GetWalletByIDQuery : ApplicationRequest<Wallet, GetWalletByIDQueryResponse>
    {
        public GetWalletByIDQuery()
        {
            ConfigKeys(x => x.WalletID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
