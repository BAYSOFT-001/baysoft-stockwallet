using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorsByFilter
{
    public class GetSubSectorsByFilterQueryResponse : ApplicationResponse<SubSector>
    {
        public GetSubSectorsByFilterQueryResponse(WrapRequest<SubSector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
