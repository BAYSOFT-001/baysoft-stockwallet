using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradeByID
{
    public class GetGradeByIDQuery : ApplicationRequest<Grade, GetGradeByIDQueryResponse>
    {
        public GetGradeByIDQuery()
        {
            ConfigKeys(x => x.StockID);

            // Configures supressed properties & response properties
            ConfigSuppressedProperties(x => x.Stock);
            ConfigSuppressedResponseProperties(x => x.Stock);
        }
    }
}
