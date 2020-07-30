using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PutSector
{
    public class PutSectorCommand : ApplicationRequest<Sector, PutSectorCommandResponse>
    {
        public PutSectorCommand()
        {
            ConfigKeys(x => x.SectorID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
