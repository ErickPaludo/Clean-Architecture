using Financ.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Application.Queries
{
    public class GetObjQuery : BaseQuery
    {
        public TransectionType Type { get; set; }
        public int IdBanco { get; set; }
        public DataQuery Date { get; set; } = new DataQuery();
        public string Description { get; set; } = string.Empty;
    }
}
