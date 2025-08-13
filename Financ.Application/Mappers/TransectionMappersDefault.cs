using Financ.Application.DTOs;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Mappers
{
    public static class TransectionMappersDefault
    {
        public static TransectionOutputDTO ToDebitoOutputDTO(Financ.Domain.Entities.Debito debito)
        {
            return new TransectionOutputDTO
            {
                Id = debito.Id,
                Titulo = debito.Titulo,
                Descricao = debito.Descricao,
                Valor = debito.Valor,
                DthrReg = debito.DthrReg,
                Status = debito.Status
            };
        }
        public static TransectionOutputDTO ToSaldoOutputDTO(Financ.Domain.Entities.Saldo saldo)
        {
            return new TransectionOutputDTO
            {
                Id = saldo.Id,
                Titulo = saldo.Titulo,
                Descricao = saldo.Descricao,
                Valor = saldo.Valor,
                DthrReg = saldo.DthrReg,
                Status = saldo.Status
            };
        }
        public static IQueryable<TransectionOutputDTO> ToDebitoOutputDTOinList(List<Financ.Domain.Entities.Debito> listDebito)
        {
            var listOut = new List<TransectionOutputDTO>();
            foreach (var debito in listDebito)
            {
                listOut.Add(ToDebitoOutputDTO(debito));
            }
            return listOut.AsQueryable();
        }
        public static IQueryable<TransectionOutputDTO> ToSaldoDTOinList(List<Financ.Domain.Entities.Saldo> listSaldo)
        {
            var listOut = new List<TransectionOutputDTO>();
            foreach (var saldo in listSaldo)
            {
                listOut.Add(ToSaldoOutputDTO(saldo));
            }
            return listOut.AsQueryable();
        }

        public static BankOutputDTO ToBancoInOutput(Financ.Domain.Entities.Banco banco)
        {
            return new BankOutputDTO { Id = banco.Id, Status = banco.Status, Titulo = banco.Titulo };
        }
        public static IQueryable<BankOutputDTO> ToBancoOutputDTOinList(IEnumerable<Financ.Domain.Entities.Banco> listBanco)
        {
            var listOut = new List<BankOutputDTO>();
            foreach (var banco in listBanco)
            {
                listOut.Add(ToBancoInOutput(banco));
            }
            return listOut.AsQueryable();
        }
    }
}
