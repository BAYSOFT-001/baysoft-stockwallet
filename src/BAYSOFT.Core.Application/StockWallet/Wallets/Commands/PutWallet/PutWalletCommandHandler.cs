using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PutWallet
{
    public class PutWalletCommandHandler : ApplicationRequestHandler<Wallet, PutWalletCommand, PutWalletCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutWalletService PutService { get; set; }
        public PutWalletCommandHandler(
            IStockWalletDbContext context,
            IPutWalletService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutWalletCommandResponse> Handle(PutWalletCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.WalletID);
            var data = await Context.Wallets.SingleOrDefaultAsync(x => x.WalletID == id);

            if (data == null)
            {
                throw new Exception("Wallet not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutWalletCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
