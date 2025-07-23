using Financ.Domain.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public sealed class Debito : Base
    {
        public Debito() { }
        public Debito(string titulo, string descricao, decimal valor, DateTime dthrreg, string status) : base(titulo, descricao, valor,dthrreg,status)
        {}
    }
}
