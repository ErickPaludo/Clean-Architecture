using Financ.Application.DTOs;
using Financ.Application.UseCases.Commands.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Mappers
{
    public static class DebitoMapper
    {
        public static DebitoOutputDTO ToDebitoOutputDTO(Financ.Domain.Entities.Debito debito)
        {
            return new DebitoOutputDTO
            {
                Id = debito.Id,
                Titulo = debito.Titulo,
                Descricao = debito.Descricao,
                Valor = debito.Valor,
                DthrReg = debito.DthrReg,
                Status = debito.Status,
                IdBanco = debito.IdBanco
            };
        }
        public static IQueryable<DebitoOutputDTO> ToDebitoOutputDTOinList(List<Financ.Domain.Entities.Debito> listDebito)
        {
            var listOut = new List<DebitoOutputDTO>();
            foreach (var debito in listDebito)
            {
                listOut.Add(ToDebitoOutputDTO(debito));
            }
            return listOut.AsQueryable();
        }

    }
}
