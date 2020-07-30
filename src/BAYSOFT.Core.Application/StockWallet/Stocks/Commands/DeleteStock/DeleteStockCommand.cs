using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommand : ApplicationRequest<Stock, DeleteStockCommandResponse>
    {
        public DeleteStockCommand()
        {
            ConfigKeys(x => x.StockID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
