﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Financ.Domain.Entities.EntityBase
{
    public abstract class Base : EntyId
    {
        public string Titulo { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public decimal Valor { get; private set; }
        public DateTime DthrReg { get; private set; }
        public string Status { get; private set; } = "N";
        public int IdFixo { get; private set; }
        public int IdBanco { get; private set; }
        protected Base() { }
        public Base(string titulo, string descricao, decimal valor, DateTime dthrreg, string status,int idBanco) : base(idBanco) 
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrreg;
            Status = status;
        }
        public Base(int id, string userId, string titulo, string descricao, decimal valor, DateTime dthrreg, string status, int idFixo, int idBanco) : base(id, userId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Valor = valor;
            DthrReg = dthrreg;
            Status = status;
            IdFixo = idFixo;
            IdBanco = idBanco;
        }
    }
}
