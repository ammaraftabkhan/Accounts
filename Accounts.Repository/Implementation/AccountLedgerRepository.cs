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
    public class AccountLedgerRepository : IAccountLedgerRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountLedgerRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            
            this.configuration = configuration;
        }

        public bool AddAccountLedger(VM_AccountLedger _VM_AccountLedger)
        {
            var getId = _AccuteDbContext.AccountLedgers.Any() ? _AccuteDbContext.AccountLedgers.Max(e => e.AcLedgerId) + 1 : 1;
            var AccountControlCode = _AccuteDbContext.AccountControls.Where(e => e.AcControlId == _VM_AccountLedger.AcControlId).Select(e => e.AcControlCode).FirstOrDefault();
            AccountLedger ob = new AccountLedger();
            ob.AcLedgerName = _VM_AccountLedger.AcLedgerName;
            ob.Createdby = _VM_AccountLedger.Createdby;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountLedger.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcControlId = _VM_AccountLedger.AcControlId;

            long? ControlId = _AccuteDbContext.AccountControls.FirstOrDefault(e => e.AcControlId == _VM_AccountLedger.AcControlId)?.AcControlId;
            
            if(ControlId != null )
            {
                if (getId < 10)
                {
                    //id.ToString();
                    ob.AcLedgerCode = AccountControlCode + "0000" + getId.ToString();
                }
                else if (getId < 100 && getId > 9)
                {
                    //id.ToString();
                    ob.AcLedgerCode = AccountControlCode + "000" + getId.ToString();
                }
                else if (getId < 1000 && getId > 99)
                {
                    //id.ToString();
                    ob.AcLedgerCode = AccountControlCode + "00" + getId.ToString();
                }
                else if (getId < 10000 && getId > 999)
                {
                    //id.ToString();
                    ob.AcLedgerCode = AccountControlCode + "0" + getId.ToString();
                }
                else if (getId < 100000 && getId > 9999)
                {
                    //id.ToString();
                    ob.AcLedgerCode = AccountControlCode + getId.ToString();
                }

                try
                {
                    _AccuteDbContext.AccountLedgers.Add(ob);
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

        public bool DeleteAccountLedger(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountLedgers.FirstOrDefault(e => e.AcLedgerId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountLedgers.Update(data);
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

        public AccountLedger FindAccountLedger(long id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountLedgers.Find(id);
                    if (find != null && find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountLedger();

                }
                catch (Exception ex)
                {
                    return new AccountLedger();
                }
            }
            return new AccountLedger();
        }

        public List<dynamic> GetAllAccountLedger([FromBody]FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountLedgers.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetAccountLedger", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;


            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountLedger(VM_AccountLedger _VM_AccountLedger)
        {
            if (_VM_AccountLedger.AcLedgerId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountLedgers.Find(_VM_AccountLedger.AcLedgerId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.AcLedgerName = _VM_AccountLedger.AcLedgerName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountLedger.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountLedgers.Update(data);
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
