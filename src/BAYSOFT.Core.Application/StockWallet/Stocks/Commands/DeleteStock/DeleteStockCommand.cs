using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommand : ApplicationRequest<Stock, DeleteStockCommandResponse>
    {
        public DeleteStockCommand()
        {
            ConfigKeys(x => x.StockID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Grade);
            ConfigSuppressedProperties(x => x.Orders);
            ConfigSuppressedProperties(x => x.Prices);
            ConfigSuppressedProperties(x => x.Stops);
            ConfigSuppressedProperties(x => x.SubSector);
            ConfigSuppressedResponseProperties(x => x.Grade);
            ConfigSuppressedResponseProperties(x => x.Orders);
            ConfigSuppressedResponseProperties(x => x.Prices);
            ConfigSuppressedResponseProperties(x => x.Stops);
            ConfigSuppressedResponseProperties(x => x.SubSector);
        }
    }
}
