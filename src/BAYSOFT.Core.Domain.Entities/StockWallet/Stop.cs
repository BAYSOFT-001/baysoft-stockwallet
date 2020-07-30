using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Stop : DomainEntity
    {
        public int StopID { get; set; }
        
        public Stop()
        {
        }
    }
}
