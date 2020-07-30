using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.DeleteSector
{
    public class DeleteSectorCommand : ApplicationRequest<Sector, DeleteSectorCommandResponse>
    {
        public DeleteSectorCommand()
        {
            ConfigKeys(x => x.SectorID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.SubSectors);
            ConfigSuppressedResponseProperties(x => x.SubSectors);
        }
    }
}
