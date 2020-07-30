using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPriceByID
{
    public class GetPriceByIDQuery : ApplicationRequest<Price, GetPriceByIDQueryResponse>
    {
        public GetPriceByIDQuery()
        {
            ConfigKeys(x => x.PriceID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
