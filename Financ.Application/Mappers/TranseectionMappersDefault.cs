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
    public static class TranseectionMappersDefault
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
                Status = debito.Status,
                IdBanco = debito.IdBanco
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

    }
}
