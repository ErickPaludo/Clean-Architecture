using Financ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class TransectionOutputDTO : TransectionInputDTO
    {
        public int Id { get; set; }
        public int IdFixo { get; set; }
    }
}
