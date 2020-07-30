using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQuery : ApplicationRequest<Order, GetOrderByIDQueryResponse>
    {
        public GetOrderByIDQuery()
        {
            ConfigKeys(x => x.OrderID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
