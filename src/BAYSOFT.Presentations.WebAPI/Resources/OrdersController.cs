using BAYSOFT.Core.Application.StockWallet.Orders.Commands.DeleteOrder;
using BAYSOFT.Core.Application.StockWallet.Orders.Commands.PatchOrder;
using BAYSOFT.Core.Application.StockWallet.Orders.Commands.PostOrder;
using BAYSOFT.Core.Application.StockWallet.Orders.Commands.PutOrder;
using BAYSOFT.Core.Application.StockWallet.Orders.Queries.GetOrderByID;
using BAYSOFT.Core.Application.StockWallet.Orders.Queries.GetOrdersByFilter;
using BAYSOFT.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class OrdersController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetOrdersByFilterQueryResponse>> Get(GetOrdersByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{orderid}")]
        public async Task<ActionResult<GetOrderByIDQueryResponse>> Get(GetOrderByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostOrderCommandResponse>> Post(PostOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{orderid}")]
        public async Task<ActionResult<PutOrderCommandResponse>> Put(PutOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{orderid}")]
        public async Task<ActionResult<PatchOrderCommandResponse>> Patch(PatchOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{orderid}")]
        public async Task<ActionResult<DeleteOrderCommandResponse>> Delete(DeleteOrderCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
