using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.PutOrder
{
    public class PutOrderCommandHandler : ApplicationRequestHandler<Order, PutOrderCommand, PutOrderCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutOrderService PutService { get; set; }
        public PutOrderCommandHandler(
            IStockWalletDbContext context,
            IPutOrderService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutOrderCommandResponse> Handle(PutOrderCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OrderID);
            var data = await Context.Orders.SingleOrDefaultAsync(x => x.OrderID == id);

            if (data == null)
            {
                throw new Exception("Order not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutOrderCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
