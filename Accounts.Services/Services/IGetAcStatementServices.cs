using Accounts.Common.Filter_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Services
{
    public interface IGetAcStatementServices
    {
        List<dynamic> GetAcStatement(LedgerFilter LFilter);
    }
}
