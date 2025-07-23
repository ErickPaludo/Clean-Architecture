using Financ.Application.UseCases.Commands.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class DebitoInputDTO : BaseDTO
    {
        public static explicit operator CriaDebCommand(DebitoInputDTO debito)
        {
            return new CriaDebCommand(debito.Titulo, debito.Descricao, debito.Valor, debito.DthrReg, debito.Status);
        }
      
    }
}
