using Financ.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Financ.Infrastructure.Entity;

namespace Financ.Infrastructure.EntitiesConfiguration
{
    internal class CreditoConfiguration : IEntityTypeConfiguration<Credito>
    {
        public void Configure(EntityTypeBuilder<Credito> builder)
        {
            builder.ToTable("fnc_tb_creditos");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Titulo).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(800);
            builder.Property(p => p.Valor).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.Status).HasDefaultValue("N").IsRequired();
            builder.Property(p => p.ValorIntegral).HasPrecision(10, 2).IsRequired();
            builder.Property(p => p.DthrReg).IsRequired();
            builder.Property(p => p.DthrLimit).IsRequired();
            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne<ApplicationUser>() 
               .WithMany()               
               .HasForeignKey(c => c.UserId)
               .HasPrincipalKey(u => u.Id)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
