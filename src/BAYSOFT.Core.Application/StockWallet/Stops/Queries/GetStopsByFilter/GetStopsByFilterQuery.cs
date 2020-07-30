using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopsByFilter
{
    public class GetStopsByFilterQuery : ApplicationRequest<Stop, GetStopsByFilterQueryResponse>
    {
        public GetStopsByFilterQuery()
        {
            ConfigKeys(x => x.StopID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
