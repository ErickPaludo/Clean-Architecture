using Financ.Domain.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public sealed class Saldo : Base
    {
        public Saldo() { }
        public Saldo(string titulo, string descricao, decimal valor, DateTime dthrreg, string status,int idBanco) : base(titulo, descricao, valor, dthrreg, status, idBanco) { }
        public static Saldo CriaObjetoSaldo(string titulo, string descricao, decimal valor, DateTime dthrreg, string status, int idBanco)
        { return new Saldo(titulo, descricao, valor, dthrreg, status, idBanco); }
    }
}
