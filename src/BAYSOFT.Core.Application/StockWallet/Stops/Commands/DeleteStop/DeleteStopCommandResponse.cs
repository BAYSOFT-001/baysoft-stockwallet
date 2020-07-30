using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.DeleteStop
{
    public class DeleteStopCommandResponse : ApplicationResponse<Stop>
    {
        public DeleteStopCommandResponse(WrapRequest<Stop> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
