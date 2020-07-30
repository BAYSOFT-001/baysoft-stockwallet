using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PutSector
{
    public class PutSectorCommandHandler : ApplicationRequestHandler<Sector, PutSectorCommand, PutSectorCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutSectorService PutService { get; set; }
        public PutSectorCommandHandler(
            IStockWalletDbContext context,
            IPutSectorService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutSectorCommandResponse> Handle(PutSectorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SectorID);
            var data = await Context.Sectors.SingleOrDefaultAsync(x => x.SectorID == id);

            if (data == null)
            {
                throw new Exception("Sector not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
