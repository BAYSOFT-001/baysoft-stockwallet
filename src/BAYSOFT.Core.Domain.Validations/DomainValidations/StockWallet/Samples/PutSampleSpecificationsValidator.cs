using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Validations.Specifications.StockWallet.Samples;
using NetDevPack.Specification;

namespace BAYSOFT.Core.Domain.Validations.DomainValidations.StockWallet.Samples
{
    public class PutSampleSpecificationsValidator : SpecValidator<Sample>
    {
        public PutSampleSpecificationsValidator(
            SampleDescriptionAlreadyExistsSpecification sampleDescriptionAlreadyExistsSpecification
        )
        {
            base.Add("SanpleMustBeUnique", new Rule<Sample>(sampleDescriptionAlreadyExistsSpecification.Not(), "A register with this description already exists!"));
        }
    }
}
