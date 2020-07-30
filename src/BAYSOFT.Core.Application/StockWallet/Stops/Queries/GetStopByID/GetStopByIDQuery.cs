using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopByID
{
    public class GetStopByIDQuery : ApplicationRequest<Stop, GetStopByIDQueryResponse>
    {
        public GetStopByIDQuery()
        {
            ConfigKeys(x => x.StopID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
