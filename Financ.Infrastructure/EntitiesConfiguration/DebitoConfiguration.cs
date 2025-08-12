using Financ.Domain.Entities;
using Financ.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.EntitiesConfiguration
{
    public class DebitoConfiguration : IEntityTypeConfiguration<Debito>
    {
        public void Configure(EntityTypeBuilder<Debito> builder)
        {
            builder.ToTable("fnc_tb_debitos");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(800);
            builder.Property(p => p.Valor).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Status).HasDefaultValue("N").IsRequired();
            builder.Property(p => p.DthrReg).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne<Banco>()
         .WithMany()
         .HasForeignKey(c => c.IdBanco)
         .HasPrincipalKey(u => u.Id)
         .OnDelete(DeleteBehavior.Restrict);

            //   builder.HasOne<ApplicationUser>()
            //.WithMany()
            //.HasForeignKey(c => c.UserId)
            //.HasPrincipalKey(u => u.Id)
            //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
