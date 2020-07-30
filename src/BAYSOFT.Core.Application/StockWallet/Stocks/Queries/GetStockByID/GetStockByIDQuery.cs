using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStockByID
{
    public class GetStockByIDQuery : ApplicationRequest<Stock, GetStockByIDQueryResponse>
    {
        public GetStockByIDQuery()
        {
            ConfigKeys(x => x.StockID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
