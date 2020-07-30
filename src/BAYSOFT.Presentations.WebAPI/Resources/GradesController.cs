﻿using BAYSOFT.Core.Application.StockWallet.Grades.Commands.DeleteGrade;
using BAYSOFT.Core.Application.StockWallet.Grades.Commands.PatchGrade;
using BAYSOFT.Core.Application.StockWallet.Grades.Commands.PostGrade;
using BAYSOFT.Core.Application.StockWallet.Grades.Commands.PutGrade;
using BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradeByID;
using BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradesByFilter;
using BAYSOFT.Presentations.WebAPI.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class GradesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetGradesByFilterQueryResponse>> Get(GetGradesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpGet("{stockid}")]
        public async Task<ActionResult<GetGradeByIDQueryResponse>> Get(GetGradeByIDQuery request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<PostGradeCommandResponse>> Post(PostGradeCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPut("{stockid}")]
        public async Task<ActionResult<PutGradeCommandResponse>> Put(PutGradeCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpPatch("{stockid}")]
        public async Task<ActionResult<PatchGradeCommandResponse>> Patch(PatchGradeCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }

        [HttpDelete("{stockid}")]
        public async Task<ActionResult<DeleteGradeCommandResponse>> Delete(DeleteGradeCommand request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
