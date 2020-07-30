using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PutPrice
{
    public class PutPriceCommand : ApplicationRequest<Price, PutPriceCommandResponse>
    {
        public PutPriceCommand()
        {
            ConfigKeys(x => x.PriceID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
