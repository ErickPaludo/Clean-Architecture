
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financ.Infrastructure.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public DateTime RefreshPassExpired { get; set; }
        public DateTime PasswordResetInterval { get; set; }
        public int RecoveryCode { get; set; }
    }
}
