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
        public decimal Valor { get; private set; }
        public DateTime DthrReg { get; private set; } = DateTime.Now;
        public string Status { get; private set; } = string.Empty;
        public int IdBanco { get; private set; }

        public CriaDebCommand() { }
        public CriaDebCommand(string titulo, string descricao, decimal valor, DateTime dthrReg, string status,int idBanco)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrReg;
            Status = status;
            IdBanco = idBanco;
            Valida();
        }
        public void Valida()
        {
            if (string.IsNullOrWhiteSpace(Titulo))
                throw new ArgumentException("Título é obrigatório");

            if (Valor <= 0)
                throw new ArgumentException("Valor deve ser maior que zero");

            if (string.IsNullOrWhiteSpace(Status) && Status.Length < 1)
                throw new ArgumentException("Staus inválido");
            
        }

    }
}

