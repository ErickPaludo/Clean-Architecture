using Financ.Domain.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public sealed class Parcela : EntyId
    {
        public int CreditoId { get; set; }

        public int Parcelas { get; set; }

        public string Status { get; set; } = "N"; 

        public Credito? Credito { get; set; }
    }
}
