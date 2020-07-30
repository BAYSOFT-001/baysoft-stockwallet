using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorsByFilter
{
    public class GetSubSectorsByFilterQuery : ApplicationRequest<SubSector, GetSubSectorsByFilterQueryResponse>
    {
        public GetSubSectorsByFilterQuery()
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
