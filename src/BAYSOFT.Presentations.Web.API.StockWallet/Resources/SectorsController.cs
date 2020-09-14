using BAYSOFT.Core.Application.StockWallet.Sectors.Commands.DeleteSector;
using BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PatchSector;
using BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PostSector;
using BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PutSector;
using BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorByID;
using BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorsByFilter;
using BAYSOFT.Presentations.Web.API.StockWallet.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Resources
{
    public class SectorsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetSectorsByFilterQueryResponse>> Get(GetSectorsByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpGet("{sectorid}")]
        public async Task<ActionResult<GetSectorByIDQueryResponse>> Get(GetSectorByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostSectorCommandResponse>> Post(PostSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPut("{sectorid}")]
        public async Task<ActionResult<PutSectorCommandResponse>> Put(PutSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPatch("{sectorid}")]
        public async Task<ActionResult<PatchSectorCommandResponse>> Patch(PatchSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpDelete("{sectorid}")]
        public async Task<ActionResult<DeleteSectorCommandResponse>> Delete(DeleteSectorCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }
    }
}
