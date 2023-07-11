using Accounts.Common.Filter_Models;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Implementation
{
    public class GetAcStatementServices : IGetAcStatementServices
    {
        private readonly IGetAcStatementRepository iGetAcStatementRepository;
        public GetAcStatementServices(IGetAcStatementRepository iGetAcStatementRepository)
        {
            this.iGetAcStatementRepository = iGetAcStatementRepository;
        }

        public List<dynamic> GetAcStatement(LedgerFilter LFilter)
        {
            return iGetAcStatementRepository.GetAcStatement(LFilter);
        }
    }
}
