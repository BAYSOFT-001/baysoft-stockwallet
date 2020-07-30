using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.PostOrder
{
    public class PostOrderCommand : ApplicationRequest<Order, PostOrderCommandResponse>
    {
        public PostOrderCommand()
        {
            ConfigKeys(x => x.OrderID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedProperties(x => x.Wallet);
            ConfigSuppressedResponseProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Wallet);
        }
    }
}
