using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletsByFilter
{
    public class GetWalletsByFilterQueryResponse : ApplicationResponse<Wallet>
    {
        public GetWalletsByFilterQueryResponse(WrapRequest<Wallet> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
