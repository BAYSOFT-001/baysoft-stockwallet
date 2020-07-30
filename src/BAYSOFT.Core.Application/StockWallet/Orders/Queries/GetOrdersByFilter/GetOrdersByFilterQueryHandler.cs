using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Queries.GetOrdersByFilter
{
    public class GetOrdersByFilterQueryHandler : IRequestHandler<GetOrdersByFilterQuery, GetOrdersByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetOrdersByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetOrdersByFilterQueryResponse> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Orders
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetOrdersByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
