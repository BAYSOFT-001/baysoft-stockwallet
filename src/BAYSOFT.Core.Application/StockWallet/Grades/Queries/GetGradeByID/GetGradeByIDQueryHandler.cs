using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradeByID
{
    public class GetGradeByIDQueryHandler : IRequestHandler<GetGradeByIDQuery, GetGradeByIDQueryResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        public GetGradeByIDQueryHandler(IStockWalletDbContext context)
        {
            Context = context;
        }
        public async Task<GetGradeByIDQueryResponse> Handle(GetGradeByIDQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.GradeID);

            var data = await Context.Grades
                .Where(x => x.GradeID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Grade not found!");
            }

            return new GetGradeByIDQueryResponse(request, data, resultCount: 1);
        }
    }
}
