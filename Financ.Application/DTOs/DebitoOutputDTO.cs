﻿using Financ.Application.UseCases.Commands.Debito;
using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class DebitoOutputDTO : BaseDTO
    {
        public int Id { get; set; }
        public int IdFixo { get; set; }
    }
}
