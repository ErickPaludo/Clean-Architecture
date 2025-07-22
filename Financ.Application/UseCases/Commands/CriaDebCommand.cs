using Financ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Commands
{
    public class CriaDebCommand : BaseDTO
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DthrReg { get; private set; }
        public string Status { get; private set; }

        public CriaDebCommand(string titulo, string descricao, decimal valor, DateTime dthrReg, string status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrReg;
            Status = status;
        }

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

