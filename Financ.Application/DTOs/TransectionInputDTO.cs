using Financ.Application.UseCases.Commands;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class TransectionInputDTO : BaseDTO
    {
        [Required]
        public int IdBanco { get; set; }

        public static explicit operator CreateTransectionCommand(TransectionInputDTO debito)
        {
            return new CreateTransectionCommand(debito.Titulo, debito.Descricao!, debito.Valor, debito.DthrReg, debito.Status,debito.IdBanco);
        }
      
    }
}
