using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PatchStock
{
    public class PatchStockCommand : ApplicationRequest<Stock, PatchStockCommandResponse>
    {
        public PatchStockCommand()
        {
            ConfigKeys(x => x.StockID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
