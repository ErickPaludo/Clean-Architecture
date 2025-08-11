using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities.EntityBase
{
    public abstract class Transections : Base
    {
        public string Descricao { get; private set; } = string.Empty;
        public decimal Valor { get; private set; }
        public DateTime DthrReg { get; private set; }
        public int IdFixo { get; private set; }
        public int IdBanco { get; private set; }

        public Transections() { }
        public Transections(string titulo, string descricao, decimal valor, DateTime dthrreg, string status, int idBanco) : base(titulo, status)
        {
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrreg;
            IdBanco = idBanco;
        }
        public Transections(int id, string userId, string titulo, string descricao, decimal valor, DateTime dthrreg, string status, int idFixo, int idBanco) : base(id, userId,titulo,status)
        {
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrreg;
            IdFixo = idFixo;
            IdBanco = idBanco;
        }
    }
}
