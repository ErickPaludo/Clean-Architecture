using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public abstract class BaseDTO
    {
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;
        [MaxLength(800)]
        public string? Descricao { get; set; } = string.Empty;
        [Required]
        [Range(minimum: 0.01, maximum: 99999999.99, ErrorMessage = "Valor mínimo de 0,01 e máximo de 9999999999.99")]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DthrReg { get; set; }
        [Required]
        [DefaultValue("N")]
        public string Status { get; set; } = "N";
        [Required]
        public TransectionType Type { get; set; }
    }
}
