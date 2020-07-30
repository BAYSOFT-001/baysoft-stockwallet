using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Sectors;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PostSector
{
    public class PostSectorCommandHandler : ApplicationRequestHandler<Sector, PostSectorCommand, PostSectorCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostSectorService PostService { get; set; }
        public PostSectorCommandHandler(
            IStockWalletDbContext context,
            IPostSectorService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostSectorCommandResponse> Handle(PostSectorCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostSectorCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
