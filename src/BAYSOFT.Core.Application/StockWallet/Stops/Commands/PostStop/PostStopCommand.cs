using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PostStop
{
    public class PostStopCommand : ApplicationRequest<Stop, PostStopCommandResponse>
    {
        public PostStopCommand()
        {
            ConfigKeys(x => x.StopID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
