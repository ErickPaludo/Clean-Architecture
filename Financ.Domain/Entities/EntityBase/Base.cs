using System;
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
        public string Status { get; private set; } = "N";

        protected Base() { }
        public Base(string titulo, string status)
        {
            Titulo = titulo;
            Status = status;
        }  
   
        public Base(int id, string userId, string titulo,string status) : base(id, userId)
        {
            Titulo = titulo;
        } public Base(string userId, string titulo,string status) : base(userId)
        {
            Titulo = titulo;
            Status = status;
        }
    }
}
