using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs.Input
{
    public class DebInDTO : BaseDTO
    {
        public static explicit operator Debito(DebInDTO debito)
        {
            return new Debito
            {
                Titulo = debito.Titulo,
                Descricao = debito.Descricao,
                Valor = debito.Valor,
                DthrReg = debito.DthrReg,
                Status = debito.Status
            };
        }
    }
}
