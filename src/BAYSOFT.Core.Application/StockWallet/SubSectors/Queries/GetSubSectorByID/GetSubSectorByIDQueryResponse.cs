using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.SubSectors.Queries.GetSubSectorByID
{
    public class GetSubSectorByIDQueryResponse : ApplicationResponse<SubSector>
    {
        public GetSubSectorByIDQueryResponse(WrapRequest<SubSector> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
