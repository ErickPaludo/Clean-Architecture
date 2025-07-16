using Financ.Domain.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public sealed class Credito : Base
    {
        public decimal ValorIntegral { get; set; }
        public DateTime DthrLimit { get; set; }
        public int TotalParcelas { get; set; }
        public ICollection<Parcela>? Parcelas { get; set; }

    }
}
