using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Price : DomainEntity
    {
        public int PriceID { get; set; }
        
        public Price()
        {
        }
    }
}
