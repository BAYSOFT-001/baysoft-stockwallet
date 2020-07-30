using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PostSubSector
{
    public class PostSubSectorCommand : ApplicationRequest<SubSector, PostSubSectorCommandResponse>
    {
        public PostSubSectorCommand()
        {
            ConfigKeys(x => x.SubSectorID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
