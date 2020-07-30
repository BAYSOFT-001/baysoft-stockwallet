using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.DeleteWallet
{
    public class DeleteWalletCommandHandler : ApplicationRequestHandler<Wallet, DeleteWalletCommand, DeleteWalletCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteWalletService DeleteService { get; set; }
        public DeleteWalletCommandHandler(
            IStockWalletDbContext context,
            IDeleteWalletService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteWalletCommandResponse> Handle(DeleteWalletCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.WalletID);

            var data = await Context.Wallets.SingleOrDefaultAsync(x => x.WalletID == id);

            if (data == null)
                throw new Exception("Wallet not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteWalletCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
