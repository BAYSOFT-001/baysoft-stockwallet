using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorByID
{
    public class GetSectorByIDQueryHandler : IRequestHandler<GetSectorByIDQuery, GetSectorByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetSectorByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetSectorByIDQueryResponse> Handle(GetSectorByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SectorID);

            var data = await Context.Sectors
                .Where(x => x.SectorID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Sector not found!");
            }

            return new GetSectorByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
