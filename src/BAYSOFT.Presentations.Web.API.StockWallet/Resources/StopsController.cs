using BAYSOFT.Core.Application.StockWallet.Stops.Commands.DeleteStop;
using BAYSOFT.Core.Application.StockWallet.Stops.Commands.PatchStop;
using BAYSOFT.Core.Application.StockWallet.Stops.Commands.PostStop;
using BAYSOFT.Core.Application.StockWallet.Stops.Commands.PutStop;
using BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopByID;
using BAYSOFT.Core.Application.StockWallet.Stops.Queries.GetStopsByFilter;
using BAYSOFT.Presentations.Web.API.StockWallet.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Resources
{
    public class StopsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetStopsByFilterQueryResponse>> Get(GetStopsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{stopid}")]
        public async Task<ActionResult<GetStopByIDQueryResponse>> Get(GetStopByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostStopCommandResponse>> Post(PostStopCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{stopid}")]
        public async Task<ActionResult<PutStopCommandResponse>> Put(PutStopCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{stopid}")]
        public async Task<ActionResult<PatchStopCommandResponse>> Patch(PatchStopCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{stopid}")]
        public async Task<ActionResult<DeleteStopCommandResponse>> Delete(DeleteStopCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
