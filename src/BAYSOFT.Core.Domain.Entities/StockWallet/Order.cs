using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Order : DomainEntity
    {
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsPurchase { get; set; }
        public int StockID { get; set; }
        public Stock Stock { get; set; }
        public int WalletID { get; set; }
        public Wallet Wallet { get; set; }
        public Order()
        {
        }
    }
}
