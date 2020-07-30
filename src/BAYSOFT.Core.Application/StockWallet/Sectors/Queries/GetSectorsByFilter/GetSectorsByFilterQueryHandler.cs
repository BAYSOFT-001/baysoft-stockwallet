using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorsByFilter
{
    public class GetSectorsByFilterQueryHandler : IRequestHandler<GetSectorsByFilterQuery, GetSectorsByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetSectorsByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetSectorsByFilterQueryResponse> Handle(GetSectorsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Sectors
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetSectorsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
