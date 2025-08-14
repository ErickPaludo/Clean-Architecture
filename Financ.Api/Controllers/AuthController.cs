using Financ.Domain.Entities;
using Financ.Infrastructure.Context;
using Financ.Infrastructure.Entity;
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
using Financ.Application.DTOs;

namespace Financ.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrerDTO user)
        {
            var userExists = await _userManager.FindByNameAsync(user.Username!);

            if (userExists != null)
            {
                return BadRequest(Result<string>.Failure("Usuário já cadastrado"));
            }

            ApplicationUser entity = new ApplicationUser
            {
                Email = user.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = user.Username,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                Surname = user.Surname
            };

            var result = await _userManager.CreateAsync(entity, user.Password!);

            if (!result.Succeeded)
            {
                return BadRequest(Result<IEnumerable<IdentityError>>.Failure(result.Errors));
            }

            return Ok(Result<string>.Success("Usuário criado com sucesso!"));

        }


    }
}

