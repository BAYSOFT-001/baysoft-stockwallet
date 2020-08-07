using BAYSOFT.Core.Application.StockWallet.Stocks.Commands.DeleteStock;
using BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PatchStock;
using BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PostStock;
using BAYSOFT.Core.Application.StockWallet.Stocks.Commands.PutStock;
using BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStockByID;
using BAYSOFT.Core.Application.StockWallet.Stocks.Queries.GetStocksByFilter;
using BAYSOFT.Presentations.Web.API.StockWallet.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Resources
{
    public class StocksController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetStocksByFilterQueryResponse>> Get(GetStocksByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{stockid}")]
        public async Task<ActionResult<GetStockByIDQueryResponse>> Get(GetStockByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostStockCommandResponse>> Post(PostStockCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{stockid}")]
        public async Task<ActionResult<PutStockCommandResponse>> Put(PutStockCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{stockid}")]
        public async Task<ActionResult<PatchStockCommandResponse>> Patch(PatchStockCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{stockid}")]
        public async Task<ActionResult<DeleteStockCommandResponse>> Delete(DeleteStockCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
