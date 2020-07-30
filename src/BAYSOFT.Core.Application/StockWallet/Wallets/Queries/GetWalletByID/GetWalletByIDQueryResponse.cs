using ModelWrapper;
using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Wallets.Queries.GetWalletByID
{
    public class GetWalletByIDQueryResponse : ApplicationResponse<Wallet>
    {
        public GetWalletByIDQueryResponse(WrapRequest<Wallet> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
}
