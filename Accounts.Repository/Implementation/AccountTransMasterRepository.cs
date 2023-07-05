using Accounts.Common;
using Accounts.Common.DataTable_Model;
using Accounts.Common.Filter_Models;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.X509;
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
        public async Task<bool> AddAccountTransMaster(VM_AccountTransMaster vM_AccountTransMaster)
        {
            var isSave = false;

            try
            {
                var TransTypeTarget = await _AccuteDbContext.AccountTransTypes.FirstOrDefaultAsync(e => e.AcTransTypeId == vM_AccountTransMaster.AcTransTypeId);
                var FiscalYearTarget = await _AccuteDbContext.AccountFiscalYears.FirstOrDefaultAsync(e => e.FiscalYearId == vM_AccountTransMaster.FiscalYearId);
                if (TransTypeTarget != null && FiscalYearTarget != null)
                {
                    var TransType = _AccuteDbContext.AccountTransTypes.Where(e => e.AcTransTypeId == vM_AccountTransMaster.AcTransTypeId).Select(e => e.AcTransTypeCode).FirstOrDefault();

                    AccountTransMaster accountTransMaster = new AccountTransMaster();
                    accountTransMaster.AcTransTypeId = vM_AccountTransMaster.AcTransTypeId;
                    accountTransMaster.AcTransDate = vM_AccountTransMaster.AcTransDate;
                    accountTransMaster.AcDocNum = vM_AccountTransMaster.AcDocNum;
                    accountTransMaster.Remarks = vM_AccountTransMaster.Remarks;
                    accountTransMaster.AcTransNum = "bc";
                    accountTransMaster.FiscalYearId = vM_AccountTransMaster.FiscalYearId;
                    accountTransMaster.PostedBy = vM_AccountTransMaster.PostedBy;
                    accountTransMaster.PostedOn = DateTime.UtcNow;
                    accountTransMaster.CreatedBy = vM_AccountTransMaster.CreatedBy;
                    accountTransMaster.CreatedOn = DateTime.UtcNow;

                    if (vM_AccountTransMaster!.vM_AccountTransDetails != null && vM_AccountTransMaster!.vM_AccountTransDetails.Count > 0)
                    {
                        accountTransMaster.AccountTransDetails = vM_AccountTransMaster.vM_AccountTransDetails.Select(x =>
                        new AccountTransDetail()
                        {
                            AccountId = x.AccountId,
                            AcContactId = x.AcContactId,
                            Remarks = x.Remarks,
                            ChqTrType = x.ChqTrType,
                            ChqTrIdNum = x.ChqTrIdNum,
                            ChqTrTitle = x.ChqTrTitle,
                            ChqTrDate = x.ChqTrDate,
                            Bank = x.Bank,
                            BankBranch = x.BankBranch,
                            AcTitle = x.AcTitle,
                            DebitAmount = x.DebitAmount,
                            CreditAmount = x.CreditAmount,
                            PostedBy = vM_AccountTransMaster.PostedBy,
                            PostedOn = DateTime.UtcNow,
                            CreatedBy = vM_AccountTransMaster.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                        }).ToList();
                    }

                    await _AccuteDbContext.AccountTransMasters.AddAsync(accountTransMaster);
                    isSave = _AccuteDbContext.SaveChanges() > 0;

                    if (isSave)
                    {
                        //var target = await _AccuteDbContext.AccountTransMasters.FirstOrDefaultAsync(x => x.AcTransMasterId == accountTransMaster.AcTransMasterId);
                        accountTransMaster!.AcTransNum = TransType + " - " + accountTransMaster?.AcTransMasterId;
                        _AccuteDbContext.AccountTransMasters.Update(accountTransMaster!);
                        isSave = _AccuteDbContext.SaveChanges() > 0;
                    }
                }

                return isSave;
            }
            catch (Exception ex)
            {
                return isSave;
            }

        }

        public async Task<bool> DeleteAccountTransMaster(int id)
        {
            var isDelete = false;
            try
            {

                if (id > 0)
                {

                    var master = await _AccuteDbContext.AccountTransMasters.FirstOrDefaultAsync(e => e.AcTransMasterId == id);
                    var detail = await _AccuteDbContext.AccountTransDetails.Where(e => e.AcTransMasterId == id).ToListAsync();

                    if (master != null && detail.Count > 0)
                    {
                        master!.IsActive = false;
                        master!.IsDeleted = true;
                        _AccuteDbContext.AccountTransMasters.Update(master!);

                        foreach (var item in detail)
                        {
                            var target = await _AccuteDbContext.AccountTransDetails.FirstOrDefaultAsync(e => e.AcTransDetailId == item.AcTransDetailId);
                            target!.IsActive = false;
                            target!.IsDeleted = true;
                            _AccuteDbContext.AccountTransDetails.Update(target!);
                        }

                        isDelete = _AccuteDbContext.SaveChanges() > 0;
                    }
                    return isDelete;

                }
                return isDelete;


            }
            catch (Exception x)
            {
                return isDelete;
            }

        }

        public async Task<VM_AccountTransMaster> FindAccountTransMaster(long id)
        {
            var isFind = new VM_AccountTransMaster();
            try
            {
                var master = await _AccuteDbContext.AccountTransMasters.FirstOrDefaultAsync(e => e.AcTransMasterId == id);
                var detail = await _AccuteDbContext.AccountTransDetails.Where(e => e.AcTransMasterId == id).ToListAsync();
                if (master != null && master.IsActive == true && master.IsDeleted == false && detail.Count > 0)
                {
                    isFind.AcDocNum = master.AcDocNum;
                    isFind.AcTransNum = master.AcTransNum;
                    isFind.AcTransDate = master.AcTransDate;
                    isFind.AcTransTypeId = master.AcTransTypeId;
                    isFind.FiscalYearId = master.FiscalYearId;
                    isFind.AcTransMasterId = master.AcTransMasterId;

                    isFind.vM_AccountTransDetails = detail.Select(x => new VM_AccountTransDetail
                    {
                        AcTransMasterId = x.AcTransMasterId,
                        AcContactId = x.AcContactId,
                        AccountId = x.AccountId,
                        AcTransDetailId = x.AcTransDetailId,
                        Remarks = x.Remarks,
                        Bank = x.Bank,
                        BankBranch = x.BankBranch,
                        AcTitle = x.AcTitle,
                        ChqTrDate = x.ChqTrDate,
                        ChqTrIdNum = x.ChqTrIdNum,
                        ChqTrTitle = x.ChqTrTitle,
                        ChqTrType = x.ChqTrType,
                        CreditAmount = x.CreditAmount,
                        DebitAmount = x.DebitAmount,
                    }).ToList();


                    return isFind;
                }
                return isFind;

            }
            catch (Exception ex)
            {
                return isFind;
            }
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
            var isUpdate = false;
            if (_VM_AccountTransMaster.AcTransMasterId > 0)
            {

                try
                {
                    var master = _AccuteDbContext.AccountTransMasters.FirstOrDefault(x => x.AcTransMasterId == _VM_AccountTransMaster.AcTransMasterId);
                    if (master != null && master.IsActive == true && master.IsDeleted == false)
                    {

                        master.AcDocNum = _VM_AccountTransMaster.AcDocNum;
                        master.AcTransDate = _VM_AccountTransMaster.AcTransDate;
                        master.Remarks = _VM_AccountTransMaster.Remarks;
                        master.FiscalYearId = _VM_AccountTransMaster.FiscalYearId;
                        master.UpdatedBy = _VM_AccountTransMaster.UpdatedBy;
                        master.UpdatedOn = DateTime.UtcNow;

                        long? FiscalYearId = _AccuteDbContext.AccountFiscalYears.FirstOrDefault(e => e.FiscalYearId == _VM_AccountTransMaster.FiscalYearId)?.FiscalYearId;

                        if (FiscalYearId != null)
                        {
                            _AccuteDbContext.AccountTransMasters.Update(master);
                            _AccuteDbContext.SaveChanges();

                            foreach (var item in _VM_AccountTransMaster.vM_AccountTransDetails!)
                            {
                                if (item.AcTransDetailId > 0)
                                {
                                    var dtlTarget = _AccuteDbContext.AccountTransDetails.FirstOrDefault(e => e.AcTransDetailId == item.AcTransDetailId)!;
                                    dtlTarget.AccountId = item.AccountId;
                                    dtlTarget.AcContactId = item.AcContactId;
                                    dtlTarget.AcTitle = item.AcTitle;
                                    dtlTarget.Bank = item.Bank;
                                    dtlTarget.BankBranch = item.BankBranch;
                                    dtlTarget.ChqTrDate = item.ChqTrDate;
                                    dtlTarget.ChqTrIdNum = item.ChqTrIdNum;
                                    dtlTarget.ChqTrTitle = item.ChqTrTitle;
                                    dtlTarget.ChqTrType = item.ChqTrType;
                                    dtlTarget.CreditAmount = item.CreditAmount;
                                    dtlTarget.DebitAmount = item.DebitAmount;
                                    dtlTarget.Remarks = item.Remarks;
                                    dtlTarget.UpdatedOn = DateTime.UtcNow;
                                    dtlTarget.UpdatedBy = item.UpdatedBy;

                                    _AccuteDbContext.AccountTransDetails.Update(dtlTarget);
                                    return isUpdate = _AccuteDbContext.SaveChanges() > 0;
                                    

                                }
                                else
                                {
                                    var accountTransDetail =
                                       new AccountTransDetail()

                                       {
                                           AccountId = item.AccountId,
                                           AcContactId = item.AcContactId,
                                           Remarks = item.Remarks,
                                           ChqTrType = item.ChqTrType,
                                           ChqTrIdNum = item.ChqTrIdNum,
                                           ChqTrTitle = item.ChqTrTitle,
                                           ChqTrDate = item.ChqTrDate,
                                           Bank = item.Bank,
                                           BankBranch = item.BankBranch,
                                           AcTitle = item.AcTitle,
                                           DebitAmount = item.DebitAmount,
                                           CreditAmount = item.CreditAmount,
                                           CreatedBy = item.CreatedBy,
                                           CreatedOn = DateTime.UtcNow,
                                           PostedBy = item.PostedBy,
                                           PostedOn = DateTime.UtcNow,
                                           AcTransMasterId = _VM_AccountTransMaster.AcTransMasterId,

                                       };

                                    _AccuteDbContext.AccountTransDetails.Add(accountTransDetail);
                                    return isUpdate =_AccuteDbContext.SaveChanges()>0;
                                }
                            }
                            return isUpdate;
                        }
                        return isUpdate;
                    }
                    return isUpdate;
                }

                catch
                {
                    return isUpdate;
                }

            }

            return isUpdate;
        }
        public List<dynamic> GetTransDtls(TransactionFilter tFilter)
        {
            try
            {
                //var list = _AccuteDbContext.AccountTransMasters.Where(e => e.IsDeleted == false).ToList();

                //return list;


                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", tFilter.PageSize);
                dynamicParameters.Add("@PageNumber", tFilter.PageNumber);
                dynamicParameters.Add("@SortColumn", tFilter.SortColumn);
                dynamicParameters.Add("@SortOrder", tFilter.SortOrder);
                dynamicParameters.Add("@SearchTerm", tFilter.SearchTerm);
                dynamicParameters.Add("@MstId", tFilter.MstId);

                db.Open();
                var data = db.Query<dynamic>("GetTransDtls", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }
    }
}
