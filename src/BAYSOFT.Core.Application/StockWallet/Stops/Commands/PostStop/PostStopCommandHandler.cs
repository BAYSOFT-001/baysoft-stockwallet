using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using BAYSOFT.Core.Domain.Interfaces.Services.StockWallet.Stops;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PostStop
{
    public class PostStopCommandHandler : ApplicationRequestHandler<Stop, PostStopCommand, PostStopCommandResponse>
    {
        private IStockWalletDbContext Context { get; set; }
        private IPostStopService PostService { get; set; }
        public PostStopCommandHandler(
            IStockWalletDbContext context,
            IPostStopService postService
        )
        {
            Context = context;
            PostService = postService;
        }
        public override async Task<PostStopCommandResponse> Handle(PostStopCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await PostService.Run(data);

            await Context.SaveChangesAsync();

            return new PostStopCommandResponse(request, data, "Successful operation!", 1);
        }
    }
}
