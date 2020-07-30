using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PatchPrice
{
    public class PatchPriceCommand : ApplicationRequest<Price, PatchPriceCommandResponse>
    {
        public PatchPriceCommand()
        {
            ConfigKeys(x => x.PriceID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
