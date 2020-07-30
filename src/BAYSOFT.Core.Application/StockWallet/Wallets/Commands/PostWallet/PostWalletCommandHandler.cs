using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Wallets;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PostWallet
{
    public class PostWalletCommandHandler : ApplicationRequestHandler<Wallet, PostWalletCommand, PostWalletCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostWalletService PostService { get; set; }
        public PostWalletCommandHandler(
            IStockWalletDbContext context,
            IPostWalletService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostWalletCommandResponse> Handle(PostWalletCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostWalletCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
