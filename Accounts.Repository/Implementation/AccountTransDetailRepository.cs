using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NPOI.POIFS.Crypt.Dsig;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class AccountTransDetailRepository : IAccountTransDetailRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountTransDetailRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail)
        {
            AccountTransDetail ob = new AccountTransDetail();
            ob.AcTransMasterId = _VM_AccountTransDetail.AcTransMasterId;
            ob.ChqTrType = _VM_AccountTransDetail.ChqTrType;
            ob.ChqTrIdNum = _VM_AccountTransDetail.ChqTrIdNum;
            ob.ChqTrDate = _VM_AccountTransDetail.ChqTrDate;
            ob.AccountId = _VM_AccountTransDetail.AccountId;
            ob.AcContactId = _VM_AccountTransDetail.AcContactId;
            ob.Remarks = _VM_AccountTransDetail.Remarks;
            ob.DebitAmount = _VM_AccountTransDetail.DebitAmount;
            ob.CreditAmount = _VM_AccountTransDetail.CreditAmount;
            ob.AcTitle = _VM_AccountTransDetail.AcTitle;
            ob.Bank = _VM_AccountTransDetail.Bank;
            ob.BankBranch = _VM_AccountTransDetail.BankBranch;
            ob.ChqTrTitle = _VM_AccountTransDetail.ChqTrTitle;
            ob.CreatedBy = _VM_AccountTransDetail.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountTransDetail.PostedBy;
            ob.PostedOn = DateTime.UtcNow;

            long? MasterId = _AccuteDbContext.AccountTransMasters.FirstOrDefault(e => e.AcTransMasterId == _VM_AccountTransDetail.AcTransMasterId)?.AcTransMasterId;
            //long? Ledgerid = _AccuteDbContext.AccountLedgers.FirstOrDefault(e => e.AcLedgerId == _VM_AccountTransDetail.PayeeAcLedgerId)?.AcLedgerId;
            long? AccountId = _AccuteDbContext.AccountSubLedgers.FirstOrDefault(e => e.AcSubLedgerId == _VM_AccountTransDetail.AccountId)?.AcSubLedgerId;
            long? ContactId  = _AccuteDbContext.AccountContacts.FirstOrDefault(e => e.AcContactId == _VM_AccountTransDetail.AcContactId)?.AcContactId;

            if (MasterId != null && /*Ledgerid == _VM_AccountTransDetail.PayeeAcLedgerId &&*/ AccountId != null && ContactId != null)
            {
                try
                {
                    _AccuteDbContext.AccountTransDetails.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            return false;
            
        }

        public bool DeleteAccountTransDetail(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransDetails.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountTransDetails.Update(data);
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

        public AccountTransDetail FindAccountTransDetial(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountTransDetails.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountTransDetail();

            }
            catch (Exception ex)
            {
                return new AccountTransDetail();
            }

            return new AccountTransDetail();
        }

        public List<dynamic> GetAllAccountTransDetail(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountTransDetails.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetTransDetails", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail)
        {
            if (_VM_AccountTransDetail.AcTransDetailId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransDetails.Find(_VM_AccountTransDetail.AcTransDetailId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        
                        data.ChqTrType = _VM_AccountTransDetail.ChqTrType;
                        data.ChqTrIdNum = _VM_AccountTransDetail.ChqTrIdNum;
                        data.ChqTrDate = _VM_AccountTransDetail.ChqTrDate;
                        data.AccountId = _VM_AccountTransDetail.AccountId;
                        data.AcContactId = _VM_AccountTransDetail.AcContactId;
                        data.Remarks = _VM_AccountTransDetail.Remarks;
                        data.DebitAmount = _VM_AccountTransDetail.DebitAmount;
                        data.CreditAmount = _VM_AccountTransDetail.CreditAmount;
                        data.AcTitle = _VM_AccountTransDetail.AcTitle;
                        data.Bank = _VM_AccountTransDetail.Bank;
                        data.BankBranch = _VM_AccountTransDetail.BankBranch;
                        data.ChqTrTitle = _VM_AccountTransDetail.ChqTrTitle;
                        data.UpdatedOn = DateTime.UtcNow;
                        data.UpdatedBy = _VM_AccountTransDetail.UpdatedBy;

                        long? AccountId = _AccuteDbContext.AccountSubLedgers.FirstOrDefault(e => e.AcSubLedgerId == _VM_AccountTransDetail.AccountId)?.AcSubLedgerId;
                        long? ContactId = _AccuteDbContext.AccountContacts.FirstOrDefault(e => e.AcContactId == _VM_AccountTransDetail.AcContactId)?.AcContactId;

                        if(AccountId != null && ContactId != null)
                        {
                            try
                            {
                                _AccuteDbContext.AccountTransDetails.Update(data);
                                return _AccuteDbContext.SaveChanges() > 0;
                            }
                            catch (Exception ex)
                            {
                                return false;
                            }
                   
                            
                        }
                        return false;

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
