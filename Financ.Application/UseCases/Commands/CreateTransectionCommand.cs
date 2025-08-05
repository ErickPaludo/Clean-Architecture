using Financ.Application.DTOs;
using Financ.Application.Service;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Commands
{
    public class CreateTransectionCommand
    {
        public string Titulo { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Valor { get; private set; }
        public DateTime DthrReg { get; private set; } = DateTime.Now;
        public string Status { get; private set; } = string.Empty;
        public int IdBanco { get; private set; }

        public CreateTransectionCommand() { }
        public CreateTransectionCommand(string titulo, string descricao, decimal valor, DateTime dthrReg, string status, int idBanco)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrReg;
            Status = status;
            IdBanco = idBanco;
        }
        public static Result<string> Valida(TransectionInputDTO debito)
        {
            if (string.IsNullOrWhiteSpace(debito.Titulo))
            {
               return Result<string>.Failure("Título é obrigatório");
            }

            if (debito.Valor <= 0)
            {
                return Result<string>.Failure("Valor deve ser maior que zero");
            }

            if (string.IsNullOrWhiteSpace(debito.Status) && debito.Status.Length < 1)
            {
                return Result<string>.Failure("Staus inválido");
            }

            return Result<string>.Success("Validação OK");
        }

    }
}

