using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Prices;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Prices.Commands.PostPrice
{
    public class PostPriceCommandHandler : ApplicationRequestHandler<Price, PostPriceCommand, PostPriceCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostPriceService PostService { get; set; }
        public PostPriceCommandHandler(
            IStockWalletDbContext context,
            IPostPriceService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostPriceCommandResponse> Handle(PostPriceCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostPriceCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
