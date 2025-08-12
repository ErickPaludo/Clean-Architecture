using Financ.Application.DTOs;
using Financ.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.UseCases.Commands
{
    public class CommandBank
    {
        public string Titulo { get; private set; } = string.Empty;
        public string Status { get; private set; } = "A";
        public string UserId { get; private set; } = string.Empty;
        public CommandBank() { }
        public CommandBank(BankInputDTO bank,string userId)
        {
            Titulo = bank.Titulo;
            Status = bank.Status;
            UserId = userId;
        }
    }
}
