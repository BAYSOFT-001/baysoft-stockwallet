using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Commands.DeleteSubSector
{
    public class DeleteSubSectorCommandResponse : ApplicationResponse<SubSector>
    {
        public DeleteSubSectorCommandResponse(WrapRequest<SubSector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
