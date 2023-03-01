﻿using Accounts.Common.Virtual_Models;
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
    public class AccountSubLedgerRepository : IAccountSubLedgerRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountSubLedgerRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountSubLedger(int id, VM_AccountSubLedger _VM_AccountsubLedger)
        {
            var getId = _AccuteDbContext.AccountSubLedgers.Any() ? _AccuteDbContext.AccountSubLedgers.Max(e => e.AcSubLedgerId) + 1 : 1;
            var AccountLedgerCode = _AccuteDbContext.AccountLedgers.Where(e => e.AcLedgerId == id).Select(e => e.AcLedgerCode).FirstOrDefault();
            AccountSubLedger ob = new AccountSubLedger();
            ob.AcSubLedgerName = _VM_AccountsubLedger.AcSubLedgerName;
            ob.CreatedBy = _VM_AccountsubLedger.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountsubLedger.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcLedgerId = Convert.ToInt64(id);

            if (id < 10)
            {
                id.ToString();
                ob.AcSubLedgerCode = AccountLedgerCode + "-00" + getId.ToString();
            }
            else if (id < 100 && id > 9)
            {
                id.ToString();
                ob.AcSubLedgerCode = AccountLedgerCode + "-0" + getId.ToString();
            }
            else if (id < 1000 && id > 99)
            {
                id.ToString();
                ob.AcSubLedgerCode = AccountLedgerCode + "-" + getId.ToString();
            }
            try
            {
                _AccuteDbContext.AccountSubLedgers.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountLSubLedger(int id)
        {
            if(id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountSubLedgers.FirstOrDefault(e => e.AcSubLedgerId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountSubLedgers.Update(data);
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

        public AccountSubLedger FindAccountSubLedger(long id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountSubLedgers.Find(id);
                    if (find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountSubLedger();

                }
                catch (Exception ex)
                {
                    return new AccountSubLedger();
                }
            }
            return new AccountSubLedger();
        }

        public List<AccountSubLedger> GetAllAccountSubLedger()
        {
            try
            {
                return _AccuteDbContext.AccountSubLedgers.ToList();
            }
            catch
            {
                return new List<AccountSubLedger>();
            }
        }

        public bool UpdateAccountSubLedger(VM_AccountSubLedger _VM_AccountSubLedger)
        {
            if (_VM_AccountSubLedger.AcSubLedgerId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountSubLedgers.Find(_VM_AccountSubLedger.AcSubLedgerId);
                    if (data != null)
                    {
                        data.AcSubLedgerName = _VM_AccountSubLedger.AcSubLedgerName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountSubLedger.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountSubLedgers.Update(data);
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
