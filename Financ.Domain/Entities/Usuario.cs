using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? Surname { get; private set; }
        public string? Email { get; private set; }
        public Usuario(int id, string firstName, string surname, string email)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Email = email;
        }
    }
}
