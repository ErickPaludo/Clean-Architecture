using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class BaseTransectionDTO <T> where T : TransectionInputDTO
    {
        [Required]
        public int BankId { get; set; }
        public TransectionType TypeTransection { get; set; }
        public T Content { get; set; } = default!;

    }
}
