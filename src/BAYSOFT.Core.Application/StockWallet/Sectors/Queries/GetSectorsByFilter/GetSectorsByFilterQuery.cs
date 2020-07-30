using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorsByFilter
{
    public class GetSectorsByFilterQuery : ApplicationRequest<Sector, GetSectorsByFilterQueryResponse>
    {
        public GetSectorsByFilterQuery()
        {
            ConfigKeys(x => x.SectorID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
