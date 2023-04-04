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
    public class AccountVoucherDetailRepository : IAccountVoucherDetailRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountVoucherDetailRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountVoucherDetail(VM_AccountVoucherDetail _VM_AccountVoucherDetail)
        {
            AccountVoucherDetail accountVoucherDetail = new AccountVoucherDetail();
            accountVoucherDetail.AcVoucherMasterId = _VM_AccountVoucherDetail.AcVoucherMasterId;
            accountVoucherDetail.AcLedgerId = _VM_AccountVoucherDetail.AcLedgerId;
            accountVoucherDetail.AcSubLedgerId = _VM_AccountVoucherDetail.AcSubLedgerId;
            accountVoucherDetail.Particulars = _VM_AccountVoucherDetail.Particulars;
            accountVoucherDetail.Debit = _VM_AccountVoucherDetail.Debit;
            accountVoucherDetail.Credit = _VM_AccountVoucherDetail.Credit;
            accountVoucherDetail.CreatedBy = _VM_AccountVoucherDetail.CreatedBy;
           
            accountVoucherDetail.PostedBy = _VM_AccountVoucherDetail.PostedBy;
            accountVoucherDetail.PostedOn = DateTime.UtcNow;

            try
            {
                _AccuteDbContext.AccountVoucherDetails.Add(accountVoucherDetail);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountVoucherDetail(int id)
        {
            if (id > 0)
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

        public AccountVoucherDetail FindAccountVoucherDetail(int id)
        {
            try
            {
                var find = _AccuteDbContext.AccountVoucherDetails.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountVoucherDetail();

            }
            catch (Exception ex)
            {
                return new AccountVoucherDetail();
            }

            return new AccountVoucherDetail();
        }

        public List<dynamic> GetAllAccountVoucherDetail(FilterModel filter)
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
                var data = db.Query<dynamic>("GetVoucherDetail", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountVoucherDetail(VM_AccountVoucherDetail _VM_AccountVoucherDetail)
        {
            if (_VM_AccountVoucherDetail.AcVoucherId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountVoucherDetails.Find(_VM_AccountVoucherDetail.AcVoucherId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        data.AcVoucherMasterId = _VM_AccountVoucherDetail.AcVoucherMasterId;
                        data.AcLedgerId = _VM_AccountVoucherDetail.AcLedgerId;
                        data.AcSubLedgerId = _VM_AccountVoucherDetail.AcSubLedgerId;
                        data.Particulars = _VM_AccountVoucherDetail.Particulars;
                        data.Debit = _VM_AccountVoucherDetail.Debit;
                        data.Credit = _VM_AccountVoucherDetail.Credit;
                        data.UpdatedBy = _VM_AccountVoucherDetail.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountVoucherDetails.Update(data);
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
