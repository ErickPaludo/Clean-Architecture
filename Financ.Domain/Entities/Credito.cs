using Financ.Domain.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public sealed class Credito : Base
    {
        public decimal ValorIntegral { get; private set; }
        public DateTime DthrLimit { get; private set; }
        public int TotalParcelas { get; private set; }
        public ICollection<Parcela>? Parcelas { get; private set; }
        public Credito() { }
        public Credito(string titulo, string descricao, decimal valor, DateTime dthrreg, string status,decimal valorIntegral,DateTime dthrLimit,int totalParcelas,int idBanco) : base(titulo, descricao, valor, dthrreg, status, idBanco)
        {
            ValorIntegral= valorIntegral;
            DthrLimit= dthrreg;
            TotalParcelas= totalParcelas;
        }
    }
}
