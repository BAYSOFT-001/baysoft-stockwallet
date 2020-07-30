using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PatchStop
{
    public class PatchStopCommandResponse : ApplicationResponse<Stop>
    {
        public PatchStopCommandResponse(WrapRequest<Stop> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
