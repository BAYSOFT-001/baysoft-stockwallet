using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Price : DomainEntity
    {
        public int PriceID { get; set; }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int StockID { get; set; }
        public Stock Stock { get; set; }
        public Price()
        {
        }
    }
}
