using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Stock : DomainEntity
    {
        public int StockID { get; set; }
        
        public Stock()
        {
        }
    }
}
