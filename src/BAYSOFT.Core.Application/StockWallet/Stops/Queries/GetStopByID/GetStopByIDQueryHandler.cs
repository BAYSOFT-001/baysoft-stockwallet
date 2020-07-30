using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopByID
{
    public class GetStopByIDQueryHandler : IRequestHandler<GetStopByIDQuery, GetStopByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetStopByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetStopByIDQueryResponse> Handle(GetStopByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StopID);

            var data = await Context.Stops
                .Where(x => x.StopID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Stop not found!");
            }

            return new GetStopByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
