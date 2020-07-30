using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.DeleteStop
{
    public class DeleteStopCommandHandler : ApplicationRequestHandler<Stop, DeleteStopCommand, DeleteStopCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteStopService DeleteService { get; set; }
        public DeleteStopCommandHandler(
            IStockWalletDbContext context,
            IDeleteStopService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteStopCommandResponse> Handle(DeleteStopCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StopID);

            var data = await Context.Stops.SingleOrDefaultAsync(x => x.StopID == id);

            if (data == null)
                throw new Exception("Stop not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteStopCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
