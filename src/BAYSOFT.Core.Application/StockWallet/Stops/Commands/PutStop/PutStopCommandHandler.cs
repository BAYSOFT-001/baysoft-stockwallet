using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PutStop
{
    public class PutStopCommandHandler : ApplicationRequestHandler<Stop, PutStopCommand, PutStopCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutStopService PutService { get; set; }
        public PutStopCommandHandler(
            IStockWalletDbContext context,
            IPutStopService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutStopCommandResponse> Handle(PutStopCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StopID);
            var data = await Context.Stops.SingleOrDefaultAsync(x => x.StopID == id);

            if (data == null)
            {
                throw new Exception("Stop not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutStopCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
