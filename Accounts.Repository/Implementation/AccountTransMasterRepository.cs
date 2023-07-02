using Accounts.Common;
using Accounts.Common.DataTable_Model;
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
        public async Task<bool> AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            var isSave = false;

            try
            {
                var TransTypeTarget = await _AccuteDbContext.AccountTransTypes.FirstOrDefaultAsync(e => e.AcTransTypeId == _VM_AccountTransMaster.AcTransTypeId);
                var FiscalYearTarget = await _AccuteDbContext.AccountFiscalYears.FirstOrDefaultAsync(e => e.FiscalYearId == _VM_AccountTransMaster.FiscalYearId);
                if (TransTypeTarget != null && FiscalYearTarget != null)
                {
                    var TransType = _AccuteDbContext.AccountTransTypes.Where(e => e.AcTransTypeId == _VM_AccountTransMaster.AcTransTypeId).Select(e => e.AcTransTypeCode).FirstOrDefault();

                    AccountTransMaster accountTransMaster = new AccountTransMaster();
                    accountTransMaster.AcTransTypeId = _VM_AccountTransMaster.AcTransTypeId;
                    accountTransMaster.AcTransDate = _VM_AccountTransMaster.AcTransDate;
                    accountTransMaster.Remarks = _VM_AccountTransMaster.Remarks;
                    accountTransMaster.AcTransNum = "bc";
                    accountTransMaster.FiscalYearId = _VM_AccountTransMaster.FiscalYearId;
                    accountTransMaster.PostedBy = _VM_AccountTransMaster.PostedBy;
                    accountTransMaster.PostedOn = DateTime.UtcNow;
                    accountTransMaster.CreatedBy = _VM_AccountTransMaster.CreatedBy;
                    accountTransMaster.CreatedOn = DateTime.UtcNow;

                    if (_VM_AccountTransMaster!.vM_AccountTransDetail != null)
                    {
                        accountTransMaster.AccountTransDetails = new List<AccountTransDetail>()
                            {
                                new AccountTransDetail()
                                {
                                     AccountId = _VM_AccountTransMaster!.vM_AccountTransDetail!.AccountId,
                                     AcContactId = _VM_AccountTransMaster!.vM_AccountTransDetail!.AcContactId,
                                     Remarks = _VM_AccountTransMaster!.vM_AccountTransDetail!.Remarks,
                                     ChqTrType = _VM_AccountTransMaster!.vM_AccountTransDetail!.ChqTrType,
                                     ChqTrIdNum = _VM_AccountTransMaster!.vM_AccountTransDetail!.ChqTrIdNum,
                                     ChqTrTitle = _VM_AccountTransMaster!.vM_AccountTransDetail!.ChqTrTitle,
                                     ChqTrDate = _VM_AccountTransMaster!.vM_AccountTransDetail!.ChqTrDate,
                                     Bank = _VM_AccountTransMaster!.vM_AccountTransDetail!.Bank,
                                     BankBranch = _VM_AccountTransMaster!.vM_AccountTransDetail!.BankBranch,
                                     AcTitle = _VM_AccountTransMaster!.vM_AccountTransDetail!.AcTitle,
                                     DebitAmount = _VM_AccountTransMaster!.vM_AccountTransDetail!.DebitAmount,
                                     CreditAmount = _VM_AccountTransMaster!.vM_AccountTransDetail!.CreditAmount,
                                     PostedBy = _VM_AccountTransMaster.PostedBy,
                                     PostedOn = DateTime.UtcNow,
                                     CreatedBy = _VM_AccountTransMaster.CreatedBy,
                                     CreatedOn = DateTime.UtcNow,
                                }
                            };
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

        public bool DeleteAccountTransMaster(int id)
        {
            int? TransId = (int?)(_AccuteDbContext.AccountTransDetails.FirstOrDefault(e => e.AcTransMasterId == id)?.AcTransMasterId);
            if (id > 0 && id != TransId)
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

                        long? FiscalYearId = _AccuteDbContext.AccountFiscalYears.FirstOrDefault(e => e.FiscalYearId == _VM_AccountTransMaster.FiscalYearId)?.FiscalYearId;

                        if (FiscalYearId != null)
                        {
                            try
                            {
                                _AccuteDbContext.AccountTransMasters.Update(data);
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
