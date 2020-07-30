using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Queries.GetOrdersByFilter
{
    public class GetOrdersByFilterQuery : ApplicationRequest<Order, GetOrdersByFilterQueryResponse>
    {
        public GetOrdersByFilterQuery()
        {
            ConfigKeys(x => x.OrderID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
