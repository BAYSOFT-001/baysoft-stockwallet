using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PostPrice
{
    public class PostPriceCommand : ApplicationRequest<Price, PostPriceCommandResponse>
    {
        public PostPriceCommand()
        {
            ConfigKeys(x => x.PriceID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
