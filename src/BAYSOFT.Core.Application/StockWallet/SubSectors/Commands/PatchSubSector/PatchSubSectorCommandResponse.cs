using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PatchSubSector
{
    public class PatchSubSectorCommandResponse : ApplicationResponse<SubSector>
    {
        public PatchSubSectorCommandResponse(WrapRequest<SubSector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
