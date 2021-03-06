using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.DeletePrice
{
    public class DeletePriceCommand : ApplicationRequest<Price, DeletePriceCommandResponse>
    {
        public DeletePriceCommand()
        {
            ConfigKeys(x => x.PriceID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
