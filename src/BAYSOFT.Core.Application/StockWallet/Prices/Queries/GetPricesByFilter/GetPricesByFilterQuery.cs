using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPricesByFilter
{
    public class GetPricesByFilterQuery : ApplicationRequest<Price, GetPricesByFilterQueryResponse>
    {
        public GetPricesByFilterQuery()
        {
            ConfigKeys(x => x.PriceID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
