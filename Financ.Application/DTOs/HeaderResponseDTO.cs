using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.DTOs
{
    public class HeaderResponseDTO<T> where T : class
    {
        public string Message { get; set; } = string.Empty;
        public int? IdBanco { get; set; }
        public T? Response { get; set; }
    }
}
