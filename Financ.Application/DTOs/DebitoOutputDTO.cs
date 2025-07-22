using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class DebitoOutputDTO : BaseDTO
    {
        public int Id { get; set; }
        public static explicit operator DebitoOutputDTO(Debito debito)
        {
            return new DebitoOutputDTO
            {
                Id = debito.Id,
                Titulo = debito.Titulo,
                Descricao = debito.Descricao,
                Valor = debito.Valor,
                DthrReg = debito.DthrReg,
                Status = debito.Status
            };
        }

    }
}
