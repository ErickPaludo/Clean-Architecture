using Financ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.EntitiesConfiguration
{
    internal class BancoConfiguration : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.ToTable("fnc_tb_banco");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
