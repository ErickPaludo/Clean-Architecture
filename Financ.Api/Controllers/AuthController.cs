using Financ.Domain.Entities;
using Financ.Infrastructure.Context;
using Financ.Infrastructure.Entity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure;
using Microsoft.AspNetCore.Identity;
using Financ.Application.Service;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Financ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationDbContext> _userManager;

        public AuthController(UserManager<ApplicationDbContext> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username!);

            if (userExists != null)
            {
                return BadReques(Result<string>.Failure("User already exists!"));
            }

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new Response { Status = "Error", Message = "User creation failed." });
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });

        }


    }
}

