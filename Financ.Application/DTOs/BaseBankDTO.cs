using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public abstract class BaseBankDTO
    {
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = "A";
    }
}
