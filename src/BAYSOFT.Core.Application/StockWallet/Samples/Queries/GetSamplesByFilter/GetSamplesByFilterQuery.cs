using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Samples.Queries.GetSamplesByFilter
{
    public class GetSamplesByFilterQuery : ApplicationRequest<Sample, GetSamplesByFilterQueryResponse>
    {
        public GetSamplesByFilterQuery()
        {
            ConfigKeys(x => x.SampleID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
