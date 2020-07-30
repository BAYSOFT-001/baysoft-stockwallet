using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.PatchOrder
{
    public class PatchOrderCommandHandler : ApplicationRequestHandler<Order, PatchOrderCommand, PatchOrderCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchOrderService PatchService { get; set; }
        public PatchOrderCommandHandler(
            IStockWalletDbContext context,
            IPatchOrderService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchOrderCommandResponse> Handle(PatchOrderCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OrderID);

            var data = await Context.Orders.SingleOrDefaultAsync(x => x.OrderID == id);

            if (data == null)
            {
                throw new Exception("Order not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchOrderCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
