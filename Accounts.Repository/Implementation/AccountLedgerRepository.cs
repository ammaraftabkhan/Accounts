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
                ob.AcLedgerCode = AccountControlCode + "0" + getId.ToString();
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
                    if (data != null)
                    {
                        _AccuteDbContext.AccountLedgers.Remove(data);
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

                    var data = _AccuteDbContext.AccountLedgers.Find(id);
                    return data;
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
                return _AccuteDbContext.AccountLedgers.ToList();
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
                    if (data != null)
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
