using Financ.Domain.Entities.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Domain.Entities
{
    public class Banco : Base
    {
        public Banco() { }
        public Banco(int id,string titulo,string userId, string status) : base(id,  userId, titulo, status) { }
        public Banco(string titulo,string userId, string status) : base(userId, titulo, status) { }
        public static Banco CriaObjectBank(string titulo, string userId, string status)
        {
            return new Banco(titulo, userId, status);
        }
    }
}
