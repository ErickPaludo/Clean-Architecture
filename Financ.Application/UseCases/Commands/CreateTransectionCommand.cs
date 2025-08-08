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

        public static explicit operator CreateTransectionCommand(BaseTransectionDTO<TransectionInputDTO> transection)
        {
            return new CreateTransectionCommand(transection.Content.Titulo, transection.Content.Descricao!, transection.Content.Valor, transection.Content.DthrReg, transection.Content.Status, transection.BankId);
        }

        public static Result<string> Valida(BaseTransectionDTO<TransectionInputDTO> entity)
        {
            if (entity.BankId <= 0)
            {
                return Result<string>.Failure(entity.BankId, "Banco inválido!");
            }
            if (string.IsNullOrWhiteSpace(entity.Content.Titulo))
            {
               return Result<string>.Failure(entity.BankId, "Título é obrigatório");
            }
            if (entity.Content.Valor <= 0)
            {
                return Result<string>.Failure(entity.BankId, "Valor deve ser maior que zero");
            }
            if (string.IsNullOrWhiteSpace(entity.Content.Status) && entity.Content.Status.Length < 1)
            {
                return Result<string>.Failure(entity.BankId, "Staus inválido");
            }
            return Result<string>.Success(entity.BankId, "Validação OK");
        }
    }
}

