using Accounts.Common.Filter_Models;
using Accounts.Core.Context;
using Accounts.Repository.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class GetAcStatementRepository : IGetAcStatementRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public GetAcStatementRepository(IConfiguration configuration)
        {
            //this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public List<dynamic> GetAcStatement(LedgerFilter LFilter)
        {
            try
            {
                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                //dynamicParameters.Add("@PageSize", LFilter.PageSize);
                //dynamicParameters.Add("@PageNumber", LFilter.PageNumber);
                //dynamicParameters.Add("@SortColumn", LFilter.SortColumn);
                //dynamicParameters.Add("@SortOrder", LFilter.SortOrder);
                //dynamicParameters.Add("@SearchTerm", LFilter.SearchTerm);
                dynamicParameters.Add("@AccountId", LFilter.AccountId);
                dynamicParameters.Add("@DateFrom", LFilter.DateFrom);
                dynamicParameters.Add("@DateTo", LFilter.DateTo);

                db.Open();
                var data = db.Query<dynamic>("GetAccountStatement", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }
    }
}
