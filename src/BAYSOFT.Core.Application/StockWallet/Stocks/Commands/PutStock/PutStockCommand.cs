using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PutStock
{
    public class PutStockCommand : ApplicationRequest<Stock, PutStockCommandResponse>
    {
        public PutStockCommand()
        {
            ConfigKeys(x => x.StockID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
