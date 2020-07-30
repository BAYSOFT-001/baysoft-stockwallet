using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPriceByID
{
    public class GetPriceByIDQueryHandler : IRequestHandler<GetPriceByIDQuery, GetPriceByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetPriceByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetPriceByIDQueryResponse> Handle(GetPriceByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.PriceID);

            var data = await Context.Prices
                .Where(x => x.PriceID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Price not found!");
            }

            return new GetPriceByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
