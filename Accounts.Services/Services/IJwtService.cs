using Accounts.Common.User;
using Accounts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IJwtService
    {
        public UserModel Authenticate(UserLogin userLogin);
        
        public string GenerateToken(UserModel user);
        
    }
}
