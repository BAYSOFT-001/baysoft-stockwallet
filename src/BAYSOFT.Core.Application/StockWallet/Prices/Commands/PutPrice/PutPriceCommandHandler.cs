using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PutPrice
{
    public class PutPriceCommandHandler : ApplicationRequestHandler<Price, PutPriceCommand, PutPriceCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutPriceService PutService { get; set; }
        public PutPriceCommandHandler(
            IStockWalletDbContext context,
            IPutPriceService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutPriceCommandResponse> Handle(PutPriceCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.PriceID);
            var data = await Context.Prices.SingleOrDefaultAsync(x => x.PriceID == id);

            if (data == null)
            {
                throw new Exception("Price not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutPriceCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
