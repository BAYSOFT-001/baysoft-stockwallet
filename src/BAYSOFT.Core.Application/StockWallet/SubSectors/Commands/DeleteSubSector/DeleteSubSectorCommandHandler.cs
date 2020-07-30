using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.DeleteSubSector
{
    public class DeleteSubSectorCommandHandler : ApplicationRequestHandler<SubSector, DeleteSubSectorCommand, DeleteSubSectorCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteSubSectorService DeleteService { get; set; }
        public DeleteSubSectorCommandHandler(
            IStockWalletDbContext context,
            IDeleteSubSectorService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteSubSectorCommandResponse> Handle(DeleteSubSectorCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SubSectorID);

            var data = await Context.SubSectors.SingleOrDefaultAsync(x => x.SubSectorID == id);

            if (data == null)
                throw new Exception("SubSector not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteSubSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
