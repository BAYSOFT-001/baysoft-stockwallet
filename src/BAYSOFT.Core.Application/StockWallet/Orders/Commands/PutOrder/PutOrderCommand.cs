using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.PutOrder
{
    public class PutOrderCommand : ApplicationRequest<Order, PutOrderCommandResponse>
    {
        public PutOrderCommand()
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
