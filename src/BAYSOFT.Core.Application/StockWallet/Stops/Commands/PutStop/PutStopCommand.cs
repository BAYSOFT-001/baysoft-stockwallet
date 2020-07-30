using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PutStop
{
    public class PutStopCommand : ApplicationRequest<Stop, PutStopCommandResponse>
    {
        public PutStopCommand()
        {
            ConfigKeys(x => x.StopID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
