using Accounts.Common.Filter_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Repository
{
    public interface IGetAcStatementRepository
    {
        List<dynamic> GetAcStatement(LedgerFilter LFilter);
    }
}
