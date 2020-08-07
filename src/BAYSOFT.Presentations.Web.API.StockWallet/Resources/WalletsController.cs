using BAYSOFT.Core.Application.StockWallet.Wallets.Commands.DeleteWallet;
using BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PatchWallet;
using BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PostWallet;
using BAYSOFT.Core.Application.StockWallet.Wallets.Commands.PutWallet;
using BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletByID;
using BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletsByFilter;
using BAYSOFT.Presentations.Web.API.StockWallet.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Resources
{
    public class WalletsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetWalletsByFilterQueryResponse>> Get(GetWalletsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{walletid}")]
        public async Task<ActionResult<GetWalletByIDQueryResponse>> Get(GetWalletByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostWalletCommandResponse>> Post(PostWalletCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{walletid}")]
        public async Task<ActionResult<PutWalletCommandResponse>> Put(PutWalletCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{walletid}")]
        public async Task<ActionResult<PatchWalletCommandResponse>> Patch(PatchWalletCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{walletid}")]
        public async Task<ActionResult<DeleteWalletCommandResponse>> Delete(DeleteWalletCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
