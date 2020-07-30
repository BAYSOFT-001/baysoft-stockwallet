using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.DeletePrice
{
    public class DeletePriceCommandHandler : ApplicationRequestHandler<Price, DeletePriceCommand, DeletePriceCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeletePriceService DeleteService { get; set; }
        public DeletePriceCommandHandler(
            IStockWalletDbContext context,
            IDeletePriceService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeletePriceCommandResponse> Handle(DeletePriceCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.PriceID);

            var data = await Context.Prices.SingleOrDefaultAsync(x => x.PriceID == id);

            if (data == null)
                throw new Exception("Price not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeletePriceCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
