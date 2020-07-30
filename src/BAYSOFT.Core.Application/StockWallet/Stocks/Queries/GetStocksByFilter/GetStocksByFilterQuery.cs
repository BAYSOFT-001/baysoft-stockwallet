using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStocksByFilter
{
    public class GetStocksByFilterQuery : ApplicationRequest<Stock, GetStocksByFilterQueryResponse>
    {
        public GetStocksByFilterQuery()
        {
            ConfigKeys(x => x.StockID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
