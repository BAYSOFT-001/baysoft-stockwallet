using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Sectors.Queries.GetSectorByID
{
    public class GetSectorByIDQueryResponse : ApplicationResponse<Sector>
    {
        public GetSectorByIDQueryResponse(WrapRequest<Sector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
