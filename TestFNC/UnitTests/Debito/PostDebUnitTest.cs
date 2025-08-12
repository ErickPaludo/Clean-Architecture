using Financ.Api.Controllers;
using Financ.Application.DTOs;
using Financ.Application.Repository.UnitOfWork;

using Financ.Infrastructure.Context;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFNC.UnitTests.Debito
{
    public class PostDebUnitTest : IClassFixture<DebitoUnitTestController>
    {
        ////private readonly DebitosController _controller;

        ////public PostDebUnitTest(DebitoUnitTestController controller)
        ////{
        ////    var usecase = new CreateTransectionUseCase(controller.repository);
        ////    _controller = new DebitosController(usecase, null);
        ////}
        ////[Fact]
        ////public async Task PostDebito_Return_StatusCodeDebitoOutDTO()
        ////{
        ////    var novoDebito = new DebitoInputDTO
        ////    {
        ////        Titulo = "Teste Unitário",
        ////        Descricao = "Descrição do teste unitário",
        ////        DthrReg = DateTime.Now,
        ////        Status = "N",
        ////        Valor = 100,
        ////        IdBanco = 0
        ////    };
        ////   var data = await _controller.CadastraDebito(novoDebito);

        ////    data.GetType();
        ////   var createdResult = data.Should().BeOfType<CreatedResult>();
        ////   createdResult.Subject.StatusCode.Should().Be(201);
        //}
        //[Fact]
        //public async Task GetDebito_Return_BadRequest()
        //{
        //    //var novoDebito = new DebitoInputDTO
        //    //{
        //    //    Titulo = null,
        //    //    Descricao = "Descrição do teste unitário",
        //    //    DthrReg = DateTime.Now,
        //    //    Status = null,
        //    //    Valor = 100,
        //    //    IdBanco = 0
        //    //};
        //  //var data = await _controller.CadastraDebito(novoDebito);

        //    //data.GetType();
        //    //var createdResult = data.Should().BeOfType<BadRequestObjectResult>();
        //    //createdResult.Subject.StatusCode.Should().Be(400);
        //}
    }
}
