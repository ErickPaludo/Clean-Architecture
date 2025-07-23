using Financ.Application.DTOs;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Commands.Debito
{
    public class CriaDebCommand
    {
        public string Titulo { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Valor { get; private set; } = 0;
        public DateTime DthrReg { get; private set; } = DateTime.Now;
        public string Status { get; private set; } = string.Empty;

        public CriaDebCommand() { }
        public CriaDebCommand(string titulo, string descricao, decimal valor, DateTime dthrReg, string status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrReg;
            Status = status;
        }
    }
}

