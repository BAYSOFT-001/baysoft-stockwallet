using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : ApplicationRequestHandler<Order, DeleteOrderCommand, DeleteOrderCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteOrderService DeleteService { get; set; }
        public DeleteOrderCommandHandler(
            IStockWalletDbContext context,
            IDeleteOrderService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OrderID);

            var data = await Context.Orders.SingleOrDefaultAsync(x => x.OrderID == id);

            if (data == null)
                throw new Exception("Order not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteOrderCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
