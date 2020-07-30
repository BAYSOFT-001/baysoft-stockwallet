using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PostStock
{
    public class PostStockCommand : ApplicationRequest<Stock, PostStockCommandResponse>
    {
        public PostStockCommand()
        {
            ConfigKeys(x => x.StockID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
