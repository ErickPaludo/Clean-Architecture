using Financ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Debito
{
    public class CriaDebCommand : BaseDTO
    {
        public static explicit operator Domain.Entities.Debito(CriaDebCommand debito)
        {
            return new Domain.Entities.Debito
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

