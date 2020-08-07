using BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.DeleteSubSector;
using BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PatchSubSector;
using BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PostSubSector;
using BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PutSubSector;
using BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorByID;
using BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorsByFilter;
using BAYSOFT.Presentations.Web.API.StockWallet.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Resources
{
    public class SubSectorsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetSubSectorsByFilterQueryResponse>> Get(GetSubSectorsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{subsectorid}")]
        public async Task<ActionResult<GetSubSectorByIDQueryResponse>> Get(GetSubSectorByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostSubSectorCommandResponse>> Post(PostSubSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{subsectorid}")]
        public async Task<ActionResult<PutSubSectorCommandResponse>> Put(PutSubSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{subsectorid}")]
        public async Task<ActionResult<PatchSubSectorCommandResponse>> Patch(PatchSubSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{subsectorid}")]
        public async Task<ActionResult<DeleteSubSectorCommandResponse>> Delete(DeleteSubSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
