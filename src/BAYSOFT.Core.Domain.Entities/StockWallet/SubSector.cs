using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class SubSector : DomainEntity
    {
        public int SubSectorID { get; set; }
        public string Description { get; set; }
        public int SectorID { get; set; }
        public Sector Sector { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public SubSector()
        {
            Stocks = new HashSet<Stock>();
        }
    }
}
