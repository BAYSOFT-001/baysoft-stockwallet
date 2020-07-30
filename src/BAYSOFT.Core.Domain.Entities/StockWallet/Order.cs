using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Order : DomainEntity
    {
        public int OrderID { get; set; }
        
        public Order()
        {
        }
    }
}
