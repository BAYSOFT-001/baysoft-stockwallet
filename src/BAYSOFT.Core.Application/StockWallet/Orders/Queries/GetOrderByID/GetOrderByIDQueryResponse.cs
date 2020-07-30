using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Queries.GetOrderByID
{
    public class GetOrderByIDQueryResponse : ApplicationResponse<Order>
    {
        public GetOrderByIDQueryResponse(WrapRequest<Order> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
