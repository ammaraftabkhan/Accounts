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
    public class AccountVoucherMasterRepository : IAccountVoucherMasterRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountVoucherMasterRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountVoucherMaster(VM_AccountVoucherMaster _VM_AccountVoucherMaster)
        {
            AccountVoucherMaster accountVoucherMaster = new AccountVoucherMaster();
            accountVoucherMaster.AcVoucherTypeId = _VM_AccountVoucherMaster.AcVoucherTypeId;
            accountVoucherMaster.FiscalYearId = _VM_AccountVoucherMaster.FiscalYearId;
            accountVoucherMaster.AcTransDate = _VM_AccountVoucherMaster.AcTransDate;
            accountVoucherMaster.AcDocNum = _VM_AccountVoucherMaster.AcDocNum;
            accountVoucherMaster.Remarks = _VM_AccountVoucherMaster.Remarks;
            accountVoucherMaster.CreatedBy = _VM_AccountVoucherMaster.CreatedBy;
            accountVoucherMaster.CreatedOn = DateTime.UtcNow;
            accountVoucherMaster.PostedBy = _VM_AccountVoucherMaster.PostedBy;
            accountVoucherMaster.PostedOn = DateTime.UtcNow;
            long? fiscalyearid = _AccuteDbContext.AccountFiscalYears.FirstOrDefault(e => e.FiscalYearId == _VM_AccountVoucherMaster.FiscalYearId)?.FiscalYearId;
            if(fiscalyearid == _VM_AccountVoucherMaster.FiscalYearId)
            {
                try
                {
                    _AccuteDbContext.AccountVoucherMasters.Add(accountVoucherMaster);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            return false;
        }

        public bool DeleteAccountVoucherMaster(int id)
        {
            int? VoucherId = (int?)(_AccuteDbContext.AccountVoucherDetails.FirstOrDefault(e => e.AcVoucherMasterId == id)?.AcVoucherMasterId);
            if (id > 0 && id != VoucherId)
            {

                try
                {
                    var data = _AccuteDbContext.AccountVoucherMasters.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountVoucherMasters.Update(data);
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

        public AccountVoucherMaster FindAccountVoucherMaster(int id)
        {
            try
            {
                var find = _AccuteDbContext.AccountVoucherMasters.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountVoucherMaster();

            }
            catch (Exception ex)
            {
                return new AccountVoucherMaster();
            }

            return new AccountVoucherMaster();
        }

        public List<dynamic> GetAllAccountVoucherMaster(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountTransTypes.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetVoucherMaster", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountVoucherMaster(VM_AccountVoucherMaster _VM_AccountVoucherMaster)
        {
            if (_VM_AccountVoucherMaster.AcVoucherMasterId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountVoucherMasters.Find(_VM_AccountVoucherMaster.AcVoucherMasterId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        data.AcVoucherTypeId = _VM_AccountVoucherMaster.AcVoucherTypeId;
                        data.UpdatedBy = _VM_AccountVoucherMaster.UpdatedBy;
                        data.FiscalYearId = _VM_AccountVoucherMaster.FiscalYearId;
                        data.AcTransDate = _VM_AccountVoucherMaster.AcTransDate;
                        data.AcDocNum = _VM_AccountVoucherMaster.AcDocNum;
                        data.Remarks = _VM_AccountVoucherMaster.Remarks;
                        data.UpdatedOn = DateTime.UtcNow;
                        data.UpdatedBy = _VM_AccountVoucherMaster.UpdatedBy; 
                        _AccuteDbContext.AccountVoucherMasters.Update(data);
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
