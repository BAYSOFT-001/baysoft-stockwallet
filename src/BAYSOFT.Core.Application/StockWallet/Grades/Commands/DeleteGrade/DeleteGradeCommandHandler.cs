using MediatR;
using Microsoft.EntityFrameworkCore;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.DeleteGrade
{
    public class DeleteGradeCommandHandler : ApplicationRequestHandler<Grade, DeleteGradeCommand, DeleteGradeCommandResponse>
    {
        public IStockWalletDbContext Context { get; set; }
        private IDeleteGradeService DeleteService { get; set; }
        public DeleteGradeCommandHandler(
            IStockWalletDbContext context,
            IDeleteGradeService deleteService)
        {
            Context = context;
            DeleteService = deleteService;
        }
        public override async Task<DeleteGradeCommandResponse> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.StockID);

            var data = await Context.Grades.SingleOrDefaultAsync(x => x.StockID == id);

            if (data == null)
                throw new Exception("Grade not found!");

            await DeleteService.Run(data);

            await Context.SaveChangesAsync();

            return new DeleteGradeCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
