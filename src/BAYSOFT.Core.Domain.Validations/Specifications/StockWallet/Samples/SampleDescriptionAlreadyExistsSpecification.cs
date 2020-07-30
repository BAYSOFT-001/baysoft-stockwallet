using BAYSOFT.Core.Domain.Entities.StockWallet;
using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Data.Contexts;
using NetDevPack.Specification;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BAYSOFT.Core.Domain.Validations.Specifications.StockWallet.Samples
{
    public class SampleDescriptionAlreadyExistsSpecification : Specification<Sample>
    {
        private IStockWalletDbContextQuery Context { get; set; }
        public SampleDescriptionAlreadyExistsSpecification(IStockWalletDbContextQuery context)
        {
            Context = context;
        }

        public override Expression<Func<Sample, bool>> ToExpression()
        {
            return sample => Context.Samples.Any(x => x.Description == sample.Description && x.SampleID != sample.SampleID);
        }
    }
}
