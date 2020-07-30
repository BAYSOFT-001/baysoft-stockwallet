using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PostSubSector
{
    public class PostSubSectorCommandResponse : ApplicationResponse<SubSector>
    {
        public PostSubSectorCommandResponse(WrapRequest<SubSector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
