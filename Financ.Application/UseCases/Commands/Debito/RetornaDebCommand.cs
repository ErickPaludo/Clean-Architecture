using Financ.Application.UseCases.Interfaces.Debito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Commands.Debito
{
    public class RetornaDebCommand : CriaDebCommand
    {
        public int Id { get; private set; }
        public int IdFixo { get; set; }
        public int IdBanco { get; set; }
        public RetornaDebCommand() { }
        public RetornaDebCommand(int id, string titulo, string descricao, decimal valor, DateTime dthrReg, string status,int idFixo,int idBanco) : base(titulo, descricao, valor, dthrReg, status)
        {
            Id = id;
            IdFixo = idFixo;
            IdBanco = idBanco;
        }
     
    }
}
