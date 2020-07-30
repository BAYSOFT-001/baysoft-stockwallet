using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStocksByFilter
{
    public class GetStocksByFilterQueryHandler : IRequestHandler<GetStocksByFilterQuery, GetStocksByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetStocksByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetStocksByFilterQueryResponse> Handle(GetStocksByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Stocks
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetStocksByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
