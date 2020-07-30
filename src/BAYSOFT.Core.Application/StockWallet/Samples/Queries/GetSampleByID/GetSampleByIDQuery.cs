using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Samples.Queries.GetSampleByID
{
    public class GetSampleByIDQuery : ApplicationRequest<Sample, GetSampleByIDQueryResponse>
    {
        public GetSampleByIDQuery()
        {
            ConfigKeys(x => x.SampleID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
