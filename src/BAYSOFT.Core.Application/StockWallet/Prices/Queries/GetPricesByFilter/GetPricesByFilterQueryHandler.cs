using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPricesByFilter
{
    public class GetPricesByFilterQueryHandler : IRequestHandler<GetPricesByFilterQuery, GetPricesByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetPricesByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetPricesByFilterQueryResponse> Handle(GetPricesByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Prices
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetPricesByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
