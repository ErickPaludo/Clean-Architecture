using Financ.Application.UseCases.Commands.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs.DebitosDto
{
    public class TransectionInputDTO : BaseDTO
    {
        public static explicit operator AddTransectionCommand(TransectionInputDTO debito)
        {
            return new AddTransectionCommand(debito.Titulo, debito.Descricao!, debito.Valor, debito.DthrReg, debito.Status,debito.IdBanco);
        }
      
    }
}
