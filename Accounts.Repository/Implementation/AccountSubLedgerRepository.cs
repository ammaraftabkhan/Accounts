using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    public class AccountSubLedgerRepository : IAccountSubLedgerRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountSubLedgerRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration; 
        }
        public bool AddAccountSubLedger(VM_AccountSubLedger _VM_AccountsubLedger)
        {
            long getId = _AccuteDbContext.AccountSubLedgers.Any() ? _AccuteDbContext.AccountSubLedgers.Max(e => e.AcSubLedgerId) + 1 : 1;
            string AccountLedgerCode = _AccuteDbContext.AccountLedgers.Where(e => e.AcLedgerId == _VM_AccountsubLedger.AcLedgerId).Select(e => e.AcLedgerCode).FirstOrDefault();
            string AccountLedgerName = _AccuteDbContext.AccountLedgers.Where(e => e.AcLedgerId == _VM_AccountsubLedger.AcLedgerId).Select(e => e.AcLedgerName).FirstOrDefault();

            AccountSubLedger ob = new AccountSubLedger();
            ob.AcSubLedgerName = AccountLedgerName + " - " + _VM_AccountsubLedger.AcSubLedgerName;
            ob.CreatedBy = _VM_AccountsubLedger.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountsubLedger.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcLedgerId = _VM_AccountsubLedger.AcLedgerId;

            long? LedgerID = _AccuteDbContext.AccountLedgers.FirstOrDefault(e => e.AcLedgerId == _VM_AccountsubLedger.AcLedgerId)?.AcLedgerId;
            if(LedgerID!=null)
            {
                if (getId < 10)
                {
                    //id.ToString();
                    ob.AcSubLedgerCode = AccountLedgerCode + "-00" + getId.ToString();
                }
                else if (getId < 100 && getId > 9)
                {
                    //id.ToString();
                    ob.AcSubLedgerCode = AccountLedgerCode + "-0" + getId.ToString();
                }
                else if (getId < 1000 && getId > 99)
                {
                    //id.ToString();
                    ob.AcSubLedgerCode = AccountLedgerCode + "-" + getId.ToString();
                }

                try
                {
                    _AccuteDbContext.AccountSubLedgers.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            else
            {
                return false;
            }

            
        }

        public bool DeleteAccountLSubLedger(int id)
        {
            if(id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountSubLedgers.FirstOrDefault(e => e.AcSubLedgerId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountSubLedgers.Update(data);
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

        public AccountSubLedger FindAccountSubLedger(long id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountSubLedgers.Find(id);
                    if (find != null && find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountSubLedger();

                }
                catch (Exception ex)
                {
                    return new AccountSubLedger();
                }
            }
            return new AccountSubLedger();
        }

        public List<dynamic> GetAllAccountSubLedger(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountSubLedgers.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetAccountSubLedger", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;


            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountSubLedger(VM_AccountSubLedger _VM_AccountSubLedger)
        {
            if (_VM_AccountSubLedger.AcSubLedgerId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountSubLedgers.Find(_VM_AccountSubLedger.AcSubLedgerId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.AcSubLedgerName = _VM_AccountSubLedger.AcSubLedgerName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountSubLedger.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountSubLedgers.Update(data);
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
