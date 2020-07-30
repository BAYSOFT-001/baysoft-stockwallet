using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Grades.Queries.GetGradesByFilter
{
    public class GetGradesByFilterQuery : ApplicationRequest<Grade, GetGradesByFilterQueryResponse>
    {
        public GetGradesByFilterQuery()
        {
            ConfigKeys(x => x.StockID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
