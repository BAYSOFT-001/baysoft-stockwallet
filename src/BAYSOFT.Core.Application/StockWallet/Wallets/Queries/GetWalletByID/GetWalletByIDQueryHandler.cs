using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletByID
{
    public class GetWalletByIDQueryHandler : IRequestHandler<GetWalletByIDQuery, GetWalletByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetWalletByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetWalletByIDQueryResponse> Handle(GetWalletByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.WalletID);

            var data = await Context.Wallets
                .Where(x => x.WalletID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Wallet not found!");
            }

            return new GetWalletByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
