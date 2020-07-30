using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PutSubSector
{
    public class PutSubSectorCommandHandler : ApplicationRequestHandler<SubSector, PutSubSectorCommand, PutSubSectorCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutSubSectorService PutService { get; set; }
        public PutSubSectorCommandHandler(
            IStockWalletDbContext context,
            IPutSubSectorService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutSubSectorCommandResponse> Handle(PutSubSectorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SubSectorID);
            var data = await Context.SubSectors.SingleOrDefaultAsync(x => x.SubSectorID == id);

            if (data == null)
            {
                throw new Exception("SubSector not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutSubSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
