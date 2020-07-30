using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PatchStop
{
    public class PatchStopCommand : ApplicationRequest<Stop, PatchStopCommandResponse>
    {
        public PatchStopCommand()
        {
            ConfigKeys(x => x.StopID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
