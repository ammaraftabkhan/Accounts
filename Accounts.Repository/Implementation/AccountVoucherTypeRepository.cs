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
    public class AccountVoucherTypeRepository : IAccountVoucherTypeRespository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountVoucherTypeRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountVoucherType(VM_AccountVoucherType _VM_AccountVoucherType)
        {
            AccountVoucherType accountVoucherType = new AccountVoucherType();
            accountVoucherType.AcVoucherTypeName = _VM_AccountVoucherType.AcVoucherTypeName;
            accountVoucherType.CreatedBy = _VM_AccountVoucherType.CreatedBy;
            accountVoucherType.CreatedOn = DateTime.UtcNow;
            accountVoucherType.PostedBy = _VM_AccountVoucherType.PostedBy;
            accountVoucherType.PostedOn = DateTime.UtcNow;

            try
            {
                _AccuteDbContext.AccountVoucherTypes.Add(accountVoucherType);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountVoucherType(int id)
        {
            int? VoucherTypeId = (int?)(_AccuteDbContext.AccountVoucherMasters.FirstOrDefault(e => e.AcVoucherTypeId == id)?.AcVoucherTypeId);
            if (id > 0 && id != VoucherTypeId)
            {

                try
                {
                    var data = _AccuteDbContext.AccountVoucherTypes.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountVoucherTypes.Update(data);
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

        public AccountVoucherType FindAccountVoucherType(int id)
        {
            try
            {
                var find = _AccuteDbContext.AccountVoucherTypes.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountVoucherType();

            }
            catch (Exception ex)
            {
                return new AccountVoucherType();
            }

            return new AccountVoucherType();
        }

        public List<dynamic> GetAllAccountVoucherType(FilterModel filter)
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
                var data = db.Query<dynamic>("GetVoucherTypes", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountVoucherType(VM_AccountVoucherType _VM_AccountVoucherType)
        {
            if (_VM_AccountVoucherType.AcVoucherTypeId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountVoucherTypes.Find(_VM_AccountVoucherType.AcVoucherTypeId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        data.AcVoucherTypeName = _VM_AccountVoucherType.AcVoucherTypeName;
                        data.UpdatedBy = _VM_AccountVoucherType.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountVoucherTypes.Update(data);
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
