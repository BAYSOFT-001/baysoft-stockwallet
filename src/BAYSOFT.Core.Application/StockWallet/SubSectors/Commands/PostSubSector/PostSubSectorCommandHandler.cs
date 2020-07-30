using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.SubSectors;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PostSubSector
{
    public class PostSubSectorCommandHandler : ApplicationRequestHandler<SubSector, PostSubSectorCommand, PostSubSectorCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostSubSectorService PostService { get; set; }
        public PostSubSectorCommandHandler(
            IStockWalletDbContext context,
            IPostSubSectorService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostSubSectorCommandResponse> Handle(PostSubSectorCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostSubSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
