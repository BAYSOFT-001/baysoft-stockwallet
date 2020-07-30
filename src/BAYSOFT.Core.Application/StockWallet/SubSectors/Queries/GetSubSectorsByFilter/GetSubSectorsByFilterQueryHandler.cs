using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorsByFilter
{
    public class GetSubSectorsByFilterQueryHandler : IRequestHandler<GetSubSectorsByFilterQuery, GetSubSectorsByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetSubSectorsByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetSubSectorsByFilterQueryResponse> Handle(GetSubSectorsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.SubSectors
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetSubSectorsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
