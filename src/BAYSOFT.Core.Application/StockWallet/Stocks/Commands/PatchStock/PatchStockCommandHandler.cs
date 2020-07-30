using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PatchStock
{
    public class PatchStockCommandHandler : ApplicationRequestHandler<Stock, PatchStockCommand, PatchStockCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchStockService PatchService { get; set; }
        public PatchStockCommandHandler(
            IStockWalletDbContext context,
            IPatchStockService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchStockCommandResponse> Handle(PatchStockCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);

            var data = await Context.Stocks.SingleOrDefaultAsync(x => x.StockID == id);

            if (data == null)
            {
                throw new Exception("Stock not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchStockCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
