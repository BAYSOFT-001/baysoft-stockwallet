using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorByID
{
    public class GetSubSectorByIDQuery : ApplicationRequest<SubSector, GetSubSectorByIDQueryResponse>
    {
        public GetSubSectorByIDQuery()
        {
            ConfigKeys(x => x.SubSectorID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Sector);
            ConfigSuppressedProperties(x => x.Stocks);
            ConfigSuppressedResponseProperties(x => x.Sector);
            ConfigSuppressedResponseProperties(x => x.Stocks);
        }
    }
}
