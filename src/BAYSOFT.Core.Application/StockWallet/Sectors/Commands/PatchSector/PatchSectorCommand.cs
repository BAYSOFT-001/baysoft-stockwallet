using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PatchSector
{
    public class PatchSectorCommand : ApplicationRequest<Sector, PatchSectorCommandResponse>
    {
        public PatchSectorCommand()
        {
            ConfigKeys(x => x.SectorID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.SubSectors);
            ConfigSuppressedResponseProperties(x => x.SubSectors);
        }
    }
}
