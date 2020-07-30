using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PutStock
{
    public class PutStockCommand : ApplicationRequest<Stock, PutStockCommandResponse>
    {
        public PutStockCommand()
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
