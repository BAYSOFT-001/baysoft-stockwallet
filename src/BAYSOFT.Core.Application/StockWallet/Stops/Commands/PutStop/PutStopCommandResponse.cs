using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PutStop
{
    public class PutStopCommandResponse : ApplicationResponse<Stop>
    {
        public PutStopCommandResponse(WrapRequest<Stop> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
