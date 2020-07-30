using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Entities.StockWallet
{
    public class Grade : DomainEntity
    {
        public int StockID { get; set; }
        public decimal SectorAndQuality { get; set; }
        public decimal RecommendedWallet { get; set; }
        public decimal Dividend { get; set; }
        public decimal ReturnOnEquity { get; set; }
        public decimal ProfitLast5Years { get; set; }
        public decimal NetMargin { get; set; }
        public decimal Indebtedness { get; set; }
        public decimal Overlap { get; set; }
        public Stock Stock { get; set; }
        public Grade()
        {
        }
    }
}
