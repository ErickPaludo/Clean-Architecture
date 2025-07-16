using Financ.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Financ.Infrastructure.Entity;

namespace Financ.Infrastructure.EntitiesConfiguration
{
    internal class ParcelaConfiguration : IEntityTypeConfiguration<Parcela>
    {
        public void Configure(EntityTypeBuilder<Parcela> builder)
        {
            builder.ToTable("fnc_tb_parcelas");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.CreditoId).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.HasOne(p => p.Credito).WithMany(c => c.Parcelas).HasForeignKey(p => p.CreditoId);

            builder.HasOne<ApplicationUser>()
         .WithMany()
         .HasForeignKey(c => c.UserId)
         .HasPrincipalKey(u => u.Id)
         .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
