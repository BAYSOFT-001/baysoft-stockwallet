using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PatchWallet
{
    public class PatchWalletCommandHandler : ApplicationRequestHandler<Wallet, PatchWalletCommand, PatchWalletCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchWalletService PatchService { get; set; }
        public PatchWalletCommandHandler(
            IStockWalletDbContext context,
            IPatchWalletService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchWalletCommandResponse> Handle(PatchWalletCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.WalletID);

            var data = await Context.Wallets.SingleOrDefaultAsync(x => x.WalletID == id);

            if (data == null)
            {
                throw new Exception("Wallet not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchWalletCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
