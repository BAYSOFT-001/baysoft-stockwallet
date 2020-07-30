using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PatchPrice
{
    public class PatchPriceCommandHandler : ApplicationRequestHandler<Price, PatchPriceCommand, PatchPriceCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchPriceService PatchService { get; set; }
        public PatchPriceCommandHandler(
            IStockWalletDbContext context,
            IPatchPriceService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchPriceCommandResponse> Handle(PatchPriceCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.PriceID);

            var data = await Context.Prices.SingleOrDefaultAsync(x => x.PriceID == id);

            if (data == null)
            {
                throw new Exception("Price not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchPriceCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
