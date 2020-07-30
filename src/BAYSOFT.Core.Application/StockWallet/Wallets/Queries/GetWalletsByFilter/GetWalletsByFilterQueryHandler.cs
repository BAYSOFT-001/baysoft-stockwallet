using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletsByFilter
{
    public class GetWalletsByFilterQueryHandler : IRequestHandler<GetWalletsByFilterQuery, GetWalletsByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetWalletsByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetWalletsByFilterQueryResponse> Handle(GetWalletsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Wallets
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetWalletsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
