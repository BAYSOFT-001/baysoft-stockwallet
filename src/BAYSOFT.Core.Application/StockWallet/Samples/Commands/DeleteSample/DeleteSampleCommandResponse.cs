using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Samples.Commands.DeleteSample
{
    public class DeleteSampleCommandResponse : ApplicationResponse<Sample>
    {
        public DeleteSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
