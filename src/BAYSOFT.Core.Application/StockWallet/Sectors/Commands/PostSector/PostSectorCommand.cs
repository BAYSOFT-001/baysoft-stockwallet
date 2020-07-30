using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PostSector
{
    public class PostSectorCommand : ApplicationRequest<Sector, PostSectorCommandResponse>
    {
        public PostSectorCommand()
        {
            ConfigKeys(x => x.SectorID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
}
