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
    public class AccountControlRepository : IAccountControlRespository
    {
        private readonly AccuteDbContext _AccuteDbContext;

        private readonly IConfiguration configuration;
        public AccountControlRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountControl(VM_AccountControl _VM_AccountControl)
        {
            var getId = _AccuteDbContext.AccountControls.Any() ? _AccuteDbContext.AccountControls.Max(e => e.AcControlId) + 1 : 1;
            var AccountHeadCode = _AccuteDbContext.AccountHeads.Where(e => e.AcHeadId == _VM_AccountControl.AcHeadId).Select(e => e.AcHeadCode).FirstOrDefault();
            
            AccountControl ob = new AccountControl();
            ob.AcControlName = _VM_AccountControl.AcControlName;
            ob.CreatedBy = _VM_AccountControl.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountControl.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcHeadId = _VM_AccountControl.AcHeadId;


            long? HeadId = _AccuteDbContext.AccountHeads.FirstOrDefault(e => e.AcHeadId == _VM_AccountControl.AcHeadId)?.AcHeadId;

            if (HeadId != null)
            {
                if (getId < 10)
                {
                    ob.AcControlCode = AccountHeadCode + "00" + getId.ToString();
                }
                else if (getId < 100 && getId > 9)
                {
                    ob.AcControlCode = AccountHeadCode + "0" + getId.ToString();
                }
                else if (getId < 1000 && getId > 99)
                {
                    ob.AcControlCode = AccountHeadCode + getId.ToString();
                }

                try
                {
                    _AccuteDbContext.AccountControls.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            return false;
        }


        public bool DeleteAccountControl(int id)
        {
            int? ControlId = (int?)(_AccuteDbContext.AccountLedgers.FirstOrDefault(e => e.AcControlId == id)?.AcControlId);
            if (id > 0 && id != ControlId)
            {

                try
                {
                    var data = _AccuteDbContext.AccountControls.FirstOrDefault(e => e.AcControlId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountControls.Update(data);
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

        public AccountControl FindAccountControl(long id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountControls.Find(id);
                    if (find != null && find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountControl();

                }
                catch (Exception ex)
                {
                    return new AccountControl();
                }
            }
            return new AccountControl();
        }

        public List<dynamic> GetAllAccountControl(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountControls.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetAccountControl", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;

            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountControl(VM_AccountControl _VM_AccountControl)
        {
            if (_VM_AccountControl.AcControlId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountControls.Find(_VM_AccountControl.AcControlId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.AcControlName = _VM_AccountControl.AcControlName;
                        data.UpdatedBy = _VM_AccountControl.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountControls.Update(data);
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
