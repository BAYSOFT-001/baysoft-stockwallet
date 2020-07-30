using BAYSOFT.Core.Domain.Entities.StockWallet;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Domain.Validations.EntityValidationsStockWallet
{
    public class SectorValidator : AbstractValidator<Sector>
    {
        public SectorValidator()
        {
        }
    }
}
