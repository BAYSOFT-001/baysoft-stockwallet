using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PutSector
{
    public class PutSectorCommandResponse : ApplicationResponse<Sector>
    {
        public PutSectorCommandResponse(WrapRequest<Sector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
