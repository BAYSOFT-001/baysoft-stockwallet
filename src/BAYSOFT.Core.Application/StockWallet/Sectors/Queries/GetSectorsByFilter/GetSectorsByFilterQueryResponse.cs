using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorsByFilter
{
    public class GetSectorsByFilterQueryResponse : ApplicationResponse<Sector>
    {
        public GetSectorsByFilterQueryResponse(WrapRequest<Sector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
