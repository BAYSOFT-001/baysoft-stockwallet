using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopsByFilter
{
    public class GetStopsByFilterQueryHandler : IRequestHandler<GetStopsByFilterQuery, GetStopsByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetStopsByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetStopsByFilterQueryResponse> Handle(GetStopsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Stops
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetStopsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
