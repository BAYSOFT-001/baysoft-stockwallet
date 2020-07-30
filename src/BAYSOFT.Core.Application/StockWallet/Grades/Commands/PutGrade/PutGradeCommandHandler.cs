using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PutGrade
{
    public class PutGradeCommandHandler : ApplicationRequestHandler<Grade, PutGradeCommand, PutGradeCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPutGradeService PutService { get; set; }
        public PutGradeCommandHandler(
            IStockWalletDbContext context,
            IPutGradeService putService)
        {
            Context = context;
            PutService = putService;
        }
        public override async Task<PutGradeCommandResponse> Handle(PutGradeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);
            var data = await Context.Grades.SingleOrDefaultAsync(x => x.StockID == id);

            if (data == null)
            {
                throw new Exception("Grade not found!");
            }

            request.Put(data);

            await PutService.Run(data);

            await Context.SaveChangesAsync();

            return new PutGradeCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
