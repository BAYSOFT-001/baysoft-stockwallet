using BAYSOFT.Core.Application.StockWallet.Prices.Commands.DeletePrice;
using BAYSOFT.Core.Application.StockWallet.Prices.Commands.PatchPrice;
using BAYSOFT.Core.Application.StockWallet.Prices.Commands.PostPrice;
using BAYSOFT.Core.Application.StockWallet.Prices.Commands.PutPrice;
using BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPriceByID;
using BAYSOFT.Core.Application.StockWallet.Prices.Queries.GetPricesByFilter;
using BAYSOFT.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class PricesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetPricesByFilterQueryResponse>> Get(GetPricesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{priceid}")]
        public async Task<ActionResult<GetPriceByIDQueryResponse>> Get(GetPriceByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostPriceCommandResponse>> Post(PostPriceCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{priceid}")]
        public async Task<ActionResult<PutPriceCommandResponse>> Put(PutPriceCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{priceid}")]
        public async Task<ActionResult<PatchPriceCommandResponse>> Patch(PatchPriceCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{priceid}")]
        public async Task<ActionResult<DeletePriceCommandResponse>> Delete(DeletePriceCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
