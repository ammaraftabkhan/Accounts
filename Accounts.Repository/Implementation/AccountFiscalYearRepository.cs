using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
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
    public class AccountFiscalYearRepository : IAccountFiscalYearRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountFiscalYearRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear)
        {
            AccountFiscalYear ob= new AccountFiscalYear();
            ob.FiscalYearName = _VM_AccountFiscalYear.FiscalYearName;
            ob.FiscalYearStart = _VM_AccountFiscalYear.FiscalYearStart;
            ob.FiscalYearEnd = _VM_AccountFiscalYear.FiscalYearEnd;

            ob.CreatedBy = _VM_AccountFiscalYear.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountFiscalYear.PostedBy;
            ob.PostedOn = DateTime.UtcNow;

            try
            {
                _AccuteDbContext.AccountFiscalYears.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public bool DeleteFiscalYear(int id)
        {
            int? TransId = (int?)(_AccuteDbContext.AccountTransMasters.FirstOrDefault(e => e.FiscalYearId == id)?.FiscalYearId);
            int? VoucherId = (int?)(_AccuteDbContext.AccountVoucherMasters.FirstOrDefault(e => e.FiscalYearId == id)?.FiscalYearId);
            if (id > 0 && id != TransId && id != VoucherId)
            {

                try
                {
                    var data = _AccuteDbContext.AccountFiscalYears.FirstOrDefault(e => e.FiscalYearId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountFiscalYears.Update(data);
                        return _AccuteDbContext.SaveChanges() > 0;
                    }
                    return false;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }

        public AccountFiscalYear FindFiscalYear(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountFiscalYears.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountFiscalYear();

            }
            catch (Exception ex)
            {
                return new AccountFiscalYear();
            }

            //return new AccountFiscalYear();
        }

        public List<dynamic> GetAllFiscalYear(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountFiscalYears.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetFiscalYears", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear)
        {
            if (_VM_AccountFiscalYear.FiscalYearId > 0)
            {

                try
                {
                    var ob = _AccuteDbContext.AccountFiscalYears.Find(_VM_AccountFiscalYear.FiscalYearId);
                    if (ob != null && ob.IsActive == true && ob.IsDeleted == false)
                    {
                        ob.FiscalYearName = _VM_AccountFiscalYear.FiscalYearName;
                        ob.FiscalYearStart = _VM_AccountFiscalYear.FiscalYearStart;
                        ob.FiscalYearEnd = _VM_AccountFiscalYear.FiscalYearEnd;

                        ob.UpdatedBy = _VM_AccountFiscalYear.UpdatedBy;
                        ob.UpdatedOn = DateTime.UtcNow;
                        ob.IsDeleted = false;
                        _AccuteDbContext.AccountFiscalYears.Update(ob);
                        return _AccuteDbContext.SaveChanges() > 0;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }

            }

            return false;
        }
    }
}
