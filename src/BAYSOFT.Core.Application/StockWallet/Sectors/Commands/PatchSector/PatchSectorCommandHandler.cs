using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PatchSector
{
    public class PatchSectorCommandHandler : ApplicationRequestHandler<Sector, PatchSectorCommand, PatchSectorCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchSectorService PatchService { get; set; }
        public PatchSectorCommandHandler(
            IStockWalletDbContext context,
            IPatchSectorService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchSectorCommandResponse> Handle(PatchSectorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SectorID);

            var data = await Context.Sectors.SingleOrDefaultAsync(x => x.SectorID == id);

            if (data == null)
            {
                throw new Exception("Sector not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
