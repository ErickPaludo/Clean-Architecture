using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class UserRegistrerDTO
    {
        [Required(ErrorMessage = "Nome de usuário é obrigatório!")]
        public string? Username { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Emais nescessário")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Preencha a senha")]
        [PasswordPropertyText]
        public string? Password { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Nome de usuário é obrigatório!")]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string? Surname { get; set; }
    }
}
