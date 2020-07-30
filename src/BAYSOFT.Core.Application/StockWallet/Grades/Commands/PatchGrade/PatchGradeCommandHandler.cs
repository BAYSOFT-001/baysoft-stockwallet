using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PatchGrade
{
    public class PatchGradeCommandHandler : ApplicationRequestHandler<Grade, PatchGradeCommand, PatchGradeCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IPatchGradeService PatchService { get; set; }
        public PatchGradeCommandHandler(
            IStockWalletDbContext context,
            IPatchGradeService patchService)
        {
            Context = context;
            PatchService = patchService;
        }
        public override async Task<PatchGradeCommandResponse> Handle(PatchGradeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);

            var data = await Context.Grades.SingleOrDefaultAsync(x => x.StockID == id);

            if (data == null)
            {
                throw new Exception("Grade not found!");
            }

            request.Patch(data);

            await PatchService.Run(data);

            await Context.SaveChangesAsync();

            return new PatchGradeCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
