using Accounts.Common;
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
    public class AccountTransMasterRepository : IAccountTransMasterRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountTransMasterRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            var VoucherId = _AccuteDbContext.AccountTransMasters.Any() ? _AccuteDbContext.AccountTransMasters.Max(e => e.AcTransTypeId) + 1 : 1;
            var VoucherType = _AccuteDbContext.AccountTransTypes.Where(e => e.AcTransTypeId == _VM_AccountTransMaster.AcTransTypeId).Select(e => e.AcTransTypeCode).FirstOrDefault();

            AccountTransMaster accountTransMaster = new AccountTransMaster();
            accountTransMaster.AcTransTypeId = _VM_AccountTransMaster.AcTransTypeId;
            accountTransMaster.AcTransNum = VoucherType + " - " + VoucherId;
            accountTransMaster.AcTransDate = _VM_AccountTransMaster.AcTransDate;
            accountTransMaster.Remarks = _VM_AccountTransMaster.Remarks;
            accountTransMaster.FiscalYearId = _VM_AccountTransMaster.FiscalYearId;
            accountTransMaster.CreatedBy = _VM_AccountTransMaster.CreatedBy;
            accountTransMaster.CreatedOn = DateTime.UtcNow;
            accountTransMaster.PostedBy = _VM_AccountTransMaster.PostedBy;
            accountTransMaster.PostedOn = DateTime.UtcNow;
            long? transtypeid = _AccuteDbContext.AccountTransTypes.FirstOrDefault(e => e.AcTransTypeId == _VM_AccountTransMaster.AcTransTypeId)?.AcTransTypeId;

            if(transtypeid == _VM_AccountTransMaster.AcTransTypeId)
            {
                try
                {
                    _AccuteDbContext.AccountTransMasters.Add(accountTransMaster);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            return false;
        }

        public bool DeleteAccountTransMaster(int id)
        {
            int? TransId = (int?)(_AccuteDbContext.AccountTransDetails.FirstOrDefault(e => e.AcTransMasterId == id)?.AcTransMasterId);
            if (id > 0 && id!= TransId)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransMasters.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountTransMasters.Update(data);
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

        public AccountTransMaster FindAccountTransMaster(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountTransMasters.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountTransMaster();

            }
            catch (Exception ex)
            {
                return new AccountTransMaster();
            }

            return new AccountTransMaster();
        }

        public List<dynamic> GetAllAccountTransMaster(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountTransMasters.Where(e => e.IsDeleted == false).ToList();

                //return list;


                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetTransMasters", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            if (_VM_AccountTransMaster.AcTransMasterId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransMasters.Find(_VM_AccountTransMaster.AcTransMasterId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        //data.AcTransTypeId = _VM_AccountTransMaster.AcTransTypeId;
                        //data.AcDocNum = _VM_AccountTransMaster.AcDocNum;
                        data.AcTransDate = _VM_AccountTransMaster.AcTransDate;
                        data.Remarks = _VM_AccountTransMaster.Remarks;
                        data.FiscalYearId = _VM_AccountTransMaster.FiscalYearId;
                        data.UpdatedBy = _VM_AccountTransMaster.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountTransMasters.Update(data);
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
