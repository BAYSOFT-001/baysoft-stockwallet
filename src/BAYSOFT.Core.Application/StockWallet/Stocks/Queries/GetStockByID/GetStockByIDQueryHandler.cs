using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStockByID
{
    public class GetStockByIDQueryHandler : IRequestHandler<GetStockByIDQuery, GetStockByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetStockByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetStockByIDQueryResponse> Handle(GetStockByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);

            var data = await Context.Stocks
                .Where(x => x.StockID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Stock not found!");
            }

            return new GetStockByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
