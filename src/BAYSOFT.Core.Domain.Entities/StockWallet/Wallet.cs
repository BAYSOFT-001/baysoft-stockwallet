using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Wallet : DomainEntity
    {
        public int WalletID { get; set; }
        
        public Wallet()
        {
        }
    }
}
