using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Orders;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Orders.Commands.PostOrder
{
    public class PostOrderCommandHandler : ApplicationRequestHandler<Order, PostOrderCommand, PostOrderCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostOrderService PostService { get; set; }
        public PostOrderCommandHandler(
            IStockWalletDbContext context,
            IPostOrderService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostOrderCommandResponse> Handle(PostOrderCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostOrderCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
