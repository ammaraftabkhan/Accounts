using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.User
{
    public class UserConstant
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="qasim",Password="qasim123",Role="Admin"}
            };
    }
}
