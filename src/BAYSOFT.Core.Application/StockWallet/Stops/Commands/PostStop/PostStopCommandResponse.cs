using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Stops.Commands.PostStop
{
    public class PostStopCommandResponse : ApplicationResponse<Stop>
    {
        public PostStopCommandResponse(WrapRequest<Stop> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
