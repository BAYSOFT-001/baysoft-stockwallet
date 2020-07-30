using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.PutSubSector
{
    public class PutSubSectorCommandResponse : ApplicationResponse<SubSector>
    {
        public PutSubSectorCommandResponse(WrapRequest<SubSector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
