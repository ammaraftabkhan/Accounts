using Accounts.Common;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class AccountTransMasterRepository : IAccountTransMasterRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountTransMasterRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountTransMaster(VM_AccountTransMaster _VM_AccountTransMaster)
        {
            AccountTransMaster accountTransMaster = new AccountTransMaster();
            accountTransMaster.AcTransTypeId = _VM_AccountTransMaster.AcTransTypeId;
            accountTransMaster.AcDocNum = _VM_AccountTransMaster.AcDocNum;
            accountTransMaster.AcTransDate = DateTime.UtcNow;
            accountTransMaster.Remarks = _VM_AccountTransMaster.Remarks;
            accountTransMaster.FiscalYearId = _VM_AccountTransMaster.FiscalYearId;
            accountTransMaster.CreatedBy = _VM_AccountTransMaster.CreatedBy;
            accountTransMaster.CreatedOn = DateTime.UtcNow;
            accountTransMaster.PostedBy = _VM_AccountTransMaster.PostedBy;
            accountTransMaster.PostedOn = DateTime.UtcNow;
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

        public bool DeleteAccountTransMaster(int id)
        {
            if (id > 0)
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

        public AccountTransMaster FindAccountTransMaster(int id)
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

        public List<AccountTransMaster> GetAllAccountTransMaster()
        {
            try
            {
                var list = _AccuteDbContext.AccountTransTypes.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountTransType>();
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

                        data.AcTransTypeId = _VM_AccountTransMaster.AcTransTypeId;
                        data.AcDocNum = _VM_AccountTransMaster.AcDocNum;
                        data.AcTransDate = DateTime.UtcNow;
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
