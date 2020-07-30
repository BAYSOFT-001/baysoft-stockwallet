using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PatchSector
{
    public class PatchSectorCommandResponse : ApplicationResponse<Sector>
    {
        public PatchSectorCommandResponse(WrapRequest<Sector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
