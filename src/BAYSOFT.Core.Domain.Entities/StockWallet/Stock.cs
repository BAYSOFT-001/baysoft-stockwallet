using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Stock : DomainEntity
    {
        public int StockID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int SubSectionID { get; set; }
        public SubSector SubSector { get; set; }
        public Grade Grade { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<Stop> Stops { get; set; }
        public Stock()
        {
            Orders = new HashSet<Order>();
            Prices = new HashSet<Price>();
            Stops = new HashSet<Stop>();
        }
    }
}
