﻿using Financ.Application.Repository;
using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Application.UseCases.Service.Debito;
using Financ.Infrastructure.Context;
using Financ.Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.CrossCutting.IoC
{
    public static class DependencyInject
    {
        public static IServiceCollection Addinfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IDebitoRepository, DebitoRepository>();
            services.AddScoped<ICreditoRepository, CreditoRepository>();
            services.AddScoped<IParcelaRepository, ParcelaRepository>();
            services.AddScoped<ISaldoRepository, SaldoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICriaDebUseCase, CriaDebUseCase>();
            services.AddScoped<IRetornaDebUseCase, RetornaDebUseCase>();
            return services;
        }
    }
}
