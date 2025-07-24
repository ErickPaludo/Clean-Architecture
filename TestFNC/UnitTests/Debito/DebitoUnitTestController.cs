using Financ.Application.Repository.UnitOfWork;
using Financ.Application.UseCases.Interfaces.Debito;
using Financ.Infrastructure.Context;
using Financ.Infrastructure.Entity;
using Financ.Infrastructure.Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFNC.UnitTests.Debito
{
    public class DebitoUnitTestController
    {
        public IUnitOfWork repository;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=25.55.129.3,1433;Database=dbfinanc;User Id=SA;Password=PlDProjeCts2025!;TrustServerCertificate=True;";

        static DebitoUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
     .UseSqlServer(connectionString)
     .Options;
        }
        public DebitoUnitTestController()
        {
            repository = new UnitOfWork(new ApplicationDbContext(dbContextOptions));
        }
    }
}
