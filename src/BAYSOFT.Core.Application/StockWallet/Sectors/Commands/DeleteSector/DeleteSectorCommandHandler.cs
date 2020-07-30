using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.DeleteSector
{
    public class DeleteSectorCommandHandler : ApplicationRequestHandler<Sector, DeleteSectorCommand, DeleteSectorCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteSectorService DeleteService { get; set; }
        public DeleteSectorCommandHandler(
            IStockWalletDbContext context,
            IDeleteSectorService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteSectorCommandResponse> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SectorID);

            var data = await Context.Sectors.SingleOrDefaultAsync(x => x.SectorID == id);

            if (data == null)
                throw new Exception("Sector not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
