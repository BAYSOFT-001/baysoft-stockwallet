using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.DeleteStop
{
    public class DeleteStopCommand : ApplicationRequest<Stop, DeleteStopCommandResponse>
    {
        public DeleteStopCommand()
        {
            ConfigKeys(x => x.StopID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
