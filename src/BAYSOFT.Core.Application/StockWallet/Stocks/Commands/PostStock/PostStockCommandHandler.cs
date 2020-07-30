using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stocks;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PostStock
{
    public class PostStockCommandHandler : ApplicationRequestHandler<Stock, PostStockCommand, PostStockCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostStockService PostService { get; set; }
        public PostStockCommandHandler(
            IStockWalletDbContext context,
            IPostStockService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostStockCommandResponse> Handle(PostStockCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostStockCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
