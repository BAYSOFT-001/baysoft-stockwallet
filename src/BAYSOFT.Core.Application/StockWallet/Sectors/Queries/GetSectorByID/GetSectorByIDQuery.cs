using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorByID
{
    public class GetSectorByIDQuery : ApplicationRequest<Sector, GetSectorByIDQueryResponse>
    {
        public GetSectorByIDQuery()
        {
            ConfigKeys(x => x.SectorID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.SubSectors);
            ConfigSuppressedResponseProperties(x => x.SubSectors);
        }
    }
}
