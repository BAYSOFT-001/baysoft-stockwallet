using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PatchStop
{
    public class PatchStopCommandHandler : ApplicationRequestHandler<Stop, PatchStopCommand, PatchStopCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchStopService PatchService { get; set; }
        public PatchStopCommandHandler(
            IStockWalletDbContext context,
            IPatchStopService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchStopCommandResponse> Handle(PatchStopCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StopID);

            var data = await Context.Stops.SingleOrDefaultAsync(x => x.StopID == id);

            if (data == null)
            {
                throw new Exception("Stop not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchStopCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
