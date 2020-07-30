using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradesByFilter
{
    public class GetGradesByFilterQueryHandler : IRequestHandler<GetGradesByFilterQuery, GetGradesByFilterQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetGradesByFilterQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetGradesByFilterQueryResponse> Handle(GetGradesByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;
            
            var data =  await Context.Grades
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            return new GetGradesByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
