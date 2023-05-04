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
    public class AccountTransTypeRepository : IAccountTransTypeRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountTransTypeRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountTransType(VM_AccountTransType _VM_AccountTransType)
        {
            AccountTransType accountTransType = new AccountTransType();
            accountTransType.AcTransTypeName = _VM_AccountTransType.AcTransTypeName;
            accountTransType.CreatedBy = _VM_AccountTransType.CreatedBy;
            accountTransType.CreatedOn = DateTime.UtcNow;
            accountTransType.PostedBy = _VM_AccountTransType.PostedBy;
            accountTransType.PostedOn = DateTime.UtcNow;
            try
            {
                _AccuteDbContext.AccountTransTypes.Add(accountTransType);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountTransType(int id)
        {
            int? TransTypeId = (int?)(_AccuteDbContext.AccountTransMasters.FirstOrDefault(e => e.AcTransTypeId == id)?.AcTransTypeId);
            if (id > 0 && id != TransTypeId)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransTypes.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountTransTypes.Update(data);
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

        public AccountTransType FindAccountTransType(int id)
        {
            try
            {
                var find = _AccuteDbContext.AccountTransTypes.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountTransType();

            }
            catch (Exception ex)
            {
                return new AccountTransType();
            }

            return new AccountTransType();
        }

        public List<dynamic> GetAllAccountTranstype(FilterModel filter)
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
                var data = db.Query<dynamic>("GetTransTypes", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountTransType(VM_AccountTransType _VM_AccountTransType)
        {
            if (_VM_AccountTransType.AcTransTypeId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransTypes.Find(_VM_AccountTransType.AcTransTypeId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        data.AcTransTypeName = _VM_AccountTransType.AcTransTypeName;
                        data.UpdatedBy = _VM_AccountTransType.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountTransTypes.Update(data);
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
