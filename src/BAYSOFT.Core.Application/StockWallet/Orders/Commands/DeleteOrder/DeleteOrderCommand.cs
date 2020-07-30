using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : ApplicationRequest<Order, DeleteOrderCommandResponse>
    {
        public DeleteOrderCommand()
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
