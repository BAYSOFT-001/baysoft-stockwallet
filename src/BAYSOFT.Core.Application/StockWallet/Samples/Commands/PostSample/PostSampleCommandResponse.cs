using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Samples.Commands.PostSample
{
    public class PostSampleCommandResponse : ApplicationResponse<Sample>
    {
        public PostSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
