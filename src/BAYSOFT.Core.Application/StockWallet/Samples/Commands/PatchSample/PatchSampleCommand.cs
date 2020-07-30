using BAYSOFT.Core.Domain.Entities.StockWallet;

namespace BAYSOFT.Core.Application.StockWallet.Samples.Commands.PatchSample
{
    public class PatchSampleCommand : ApplicationRequest<Sample, PatchSampleCommandResponse>
    {
        public PatchSampleCommand()
        {
            ConfigKeys(x => x.SampleID);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);
        }
    }
}
