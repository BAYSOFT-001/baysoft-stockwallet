using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Commands.PostSector
{
    public class PostSectorCommandResponse : ApplicationResponse<Sector>
    {
        public PostSectorCommandResponse(WrapRequest<Sector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
