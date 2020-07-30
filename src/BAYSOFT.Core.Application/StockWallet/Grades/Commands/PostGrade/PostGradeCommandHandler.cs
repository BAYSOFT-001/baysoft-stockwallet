using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Grades;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Commands.PostGrade
{
    public class PostGradeCommandHandler : ApplicationRequestHandler<Grade, PostGradeCommand, PostGradeCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostGradeService PostService { get; set; }
        public PostGradeCommandHandler(
            IStockWalletDbContext context,
            IPostGradeService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostGradeCommandResponse> Handle(PostGradeCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostGradeCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
