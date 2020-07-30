using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Stop : DomainEntity
    {
        public int StopID { get; set; }
        public decimal Gain1 { get; set; }
        public decimal Gain2 { get; set; }
        public decimal Loss { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? ExclusionDate { get; set; }
        public int StockID { get; set; }
        public Stock Stock { get; set; }

        public Stop()
        {
        }
    }
}
