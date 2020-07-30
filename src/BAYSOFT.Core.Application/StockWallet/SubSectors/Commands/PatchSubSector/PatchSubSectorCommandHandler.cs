using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PatchSubSector
{
    public class PatchSubSectorCommandHandler : ApplicationRequestHandler<SubSector, PatchSubSectorCommand, PatchSubSectorCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchSubSectorService PatchService { get; set; }
        public PatchSubSectorCommandHandler(
            IStockWalletDbContext context,
            IPatchSubSectorService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchSubSectorCommandResponse> Handle(PatchSubSectorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SubSectorID);

            var data = await Context.SubSectors.SingleOrDefaultAsync(x => x.SubSectorID == id);

            if (data == null)
            {
                throw new Exception("SubSector not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchSubSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
