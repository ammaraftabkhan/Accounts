using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Reset
{
    public class ResetPassword
    {
        public string Password { get; set; } = null!;
        [Compare("Password", ErrorMessage = "The Password and configuration password do not match.")]
        public string ConfrimPassword { get; set; } = null!;

        public string  Email { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
