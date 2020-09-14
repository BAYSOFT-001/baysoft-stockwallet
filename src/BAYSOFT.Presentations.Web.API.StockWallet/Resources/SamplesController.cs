using BAYSOFT.Core.Application.StockWallet.Samples.Commands.DeleteSample;
using BAYSOFT.Core.Application.StockWallet.Samples.Commands.PatchSample;
using BAYSOFT.Core.Application.StockWallet.Samples.Commands.PostSample;
using BAYSOFT.Core.Application.StockWallet.Samples.Commands.PutSample;
using BAYSOFT.Core.Application.StockWallet.Samples.Queries.GetSampleByID;
using BAYSOFT.Core.Application.StockWallet.Samples.Queries.GetSamplesByFilter;
using BAYSOFT.Presentations.Web.API.StockWallet.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.Web.API.StockWallet.Resources
{
    public class SamplesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetSamplesByFilterQueryResponse>> Get(GetSamplesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpGet("{sampleid}")]
        public async Task<ActionResult<GetSampleByIDQueryResponse>> Get(GetSampleByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostSampleCommandResponse>> Post(PostSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPut("{sampleid}")]
        public async Task<ActionResult<PutSampleCommandResponse>> Put(PutSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpPatch("{sampleid}")]
        public async Task<ActionResult<PatchSampleCommandResponse>> Patch(PatchSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }

        [HttpDelete("{sampleid}")]
        public async Task<ActionResult<DeleteSampleCommandResponse>> Delete(DeleteSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(request, cancellationToken);
        }
    }
}
