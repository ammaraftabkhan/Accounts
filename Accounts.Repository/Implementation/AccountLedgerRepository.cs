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
    public class AccountLedgerRepository : IAccountLedgerRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountLedgerRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool AddAccountLedger(int id, VM_AccountLedger _VM_AccountLedger)
        {
            var getId = _AccuteDbContext.AccountLedgers.Any() ? _AccuteDbContext.AccountLedgers.Max(e => e.AcLedgerId) + 1 : 1;
            var AccountControlCode = _AccuteDbContext.AccountControls.Where(e => e.AcControlId == id).Select(e => e.AcControlCode).FirstOrDefault();
            AccountLedger ob = new AccountLedger();
            ob.AcLedgerName = _VM_AccountLedger.AcLedgerName;
            ob.Createdby = _VM_AccountLedger.Createdby;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountLedger.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcControlId = Convert.ToInt64(id);

            if (id < 10)
            {
                id.ToString();
                ob.AcLedgerCode = AccountControlCode + "0000" + getId.ToString();
            }
            else if (id < 100 && id > 9)
            {
                id.ToString();
                ob.AcLedgerCode = AccountControlCode + "000" + getId.ToString();
            }
            else if (id < 1000 && id > 99)
            {
                id.ToString();
                ob.AcLedgerCode = AccountControlCode + "00" + getId.ToString();
            }
            else if (id < 10000 && id > 999)
            {
                id.ToString();
                ob.AcLedgerCode = AccountControlCode + "0" + getId.ToString();
            }
            else if (id < 100000 && id > 9999)
            {
                id.ToString();
                ob.AcLedgerCode = AccountControlCode + getId.ToString();
            }
            try
            {
                _AccuteDbContext.AccountLedgers.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountLedger(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountLedgers.FirstOrDefault(e => e.AcLedgerId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountLedgers.Update(data);
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

        public AccountLedger FindAccountLedger(long id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountLedgers.Find(id);
                    if (find != null && find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountLedger();

                }
                catch (Exception ex)
                {
                    return new AccountLedger();
                }
            }
            return new AccountLedger();
        }

        public List<AccountLedger> GetAllAccountLedger()
        {
            try
            {
                var list = _AccuteDbContext.AccountLedgers.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountLedger>();
            }
        }

        public bool UpdateAccountLedger(VM_AccountLedger _VM_AccountLedger)
        {
            if (_VM_AccountLedger.AcLedgerId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountLedgers.Find(_VM_AccountLedger.AcLedgerId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.AcLedgerName = _VM_AccountLedger.AcLedgerName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountLedger.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountLedgers.Update(data);
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
