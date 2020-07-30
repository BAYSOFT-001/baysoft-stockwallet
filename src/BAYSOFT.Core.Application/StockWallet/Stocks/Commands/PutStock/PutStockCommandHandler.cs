using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PutStock
{
    public class PutStockCommandHandler : ApplicationRequestHandler<Stock, PutStockCommand, PutStockCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutStockService PutService { get; set; }
        public PutStockCommandHandler(
            IStockWalletDbContext context,
            IPutStockService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutStockCommandResponse> Handle(PutStockCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);
            var data = await Context.Stocks.SingleOrDefaultAsync(x => x.StockID == id);

            if (data == null)
            {
                throw new Exception("Stock not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutStockCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
