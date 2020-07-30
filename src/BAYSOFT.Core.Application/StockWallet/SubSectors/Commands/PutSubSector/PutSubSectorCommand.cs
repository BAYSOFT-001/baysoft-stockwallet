using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PutSubSector
{
    public class PutSubSectorCommand : ApplicationRequest<SubSector, PutSubSectorCommandResponse>
    {
        public PutSubSectorCommand()
        {
            ConfigKeys(x => x.SubSectorID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
