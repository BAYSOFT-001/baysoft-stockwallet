using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorByID
{
    public class GetSubSectorByIDQueryHandler : IRequestHandler<GetSubSectorByIDQuery, GetSubSectorByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetSubSectorByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetSubSectorByIDQueryResponse> Handle(GetSubSectorByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SubSectorID);

            var data = await Context.SubSectors
                .Where(x => x.SubSectorID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("SubSector not found!");
            }

            return new GetSubSectorByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
