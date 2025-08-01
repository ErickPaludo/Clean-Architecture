﻿using Financ.Domain.Entities;
using Financ.Infrastructure.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Debito> Debitos { get; set; }
        public DbSet<Saldo> Saldos { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Debito>(entity =>
            {
                entity.Property(d => d.Descricao).IsRequired(false);
            });
            builder.Entity<Saldo>(entity =>
            {
                entity.Property(s => s.Descricao).IsRequired(false);
            });  
            builder.Entity<Credito>(entity =>
            {
                entity.Property(c => c.Descricao).IsRequired(false);
            });

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
                .Assembly);
        }
    }
}
