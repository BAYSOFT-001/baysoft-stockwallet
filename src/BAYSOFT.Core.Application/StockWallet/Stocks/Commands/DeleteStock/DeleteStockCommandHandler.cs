using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandHandler : ApplicationRequestHandler<Stock, DeleteStockCommand, DeleteStockCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteStockService DeleteService { get; set; }
        public DeleteStockCommandHandler(
            IStockWalletDbContext context,
            IDeleteStockService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteStockCommandResponse> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);

            var data = await Context.Stocks.SingleOrDefaultAsync(x => x.StockID == id);

            if (data == null)
                throw new Exception("Stock not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteStockCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
