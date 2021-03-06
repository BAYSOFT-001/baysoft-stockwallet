using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Sector : DomainEntity
    {
        public int SectorID { get; set; }
        public string Description { get; set; }
        public ICollection<SubSector> SubSectors { get; set; }

        public Sector()
        {
            SubSectors = new HashSet<SubSector>();
        }
    }
}
