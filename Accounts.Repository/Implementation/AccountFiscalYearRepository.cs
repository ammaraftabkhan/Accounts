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
    public class AccountFiscalYearRepository : IAccountFiscalYearRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountFiscalYearRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear)
        {
            AccountFiscalYear ob= new AccountFiscalYear();
            ob.FiscalYearName = _VM_AccountFiscalYear.FiscalYearName;
            ob.FiscalYearStart = _VM_AccountFiscalYear.FiscalYearStart;
            ob.FiscalYearEnd = _VM_AccountFiscalYear.FiscalYearEnd;

            ob.CreatedBy = _VM_AccountFiscalYear.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountFiscalYear.PostedBy;
            ob.PostedOn = DateTime.UtcNow;

            try
            {
                _AccuteDbContext.AccountFiscalYears.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }

        }

        public bool DeleteFiscalYear(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountFiscalYears.FirstOrDefault(e => e.FiscalYearId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountFiscalYears.Update(data);
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

        public AccountFiscalYear FindFiscalYear(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountFiscalYears.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountFiscalYear();

            }
            catch (Exception ex)
            {
                return new AccountFiscalYear();
            }

            return new AccountFiscalYear();
        }

        public List<AccountFiscalYear> GetAllFiscalYear()
        {
            try
            {
                var list = _AccuteDbContext.AccountFiscalYears.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountFiscalYear>();
            }
        }

        public bool UpdateFiscalYear(VM_AccountFiscalYear _VM_AccountFiscalYear)
        {
            if (_VM_AccountFiscalYear.FiscalYearId > 0)
            {

                try
                {
                    var ob = _AccuteDbContext.AccountFiscalYears.Find(_VM_AccountFiscalYear.FiscalYearId);
                    if (ob != null && ob.IsActive == true && ob.IsDeleted == false)
                    {
                        ob.FiscalYearName = _VM_AccountFiscalYear.FiscalYearName;
                        ob.FiscalYearStart = _VM_AccountFiscalYear.FiscalYearStart;
                        ob.FiscalYearEnd = _VM_AccountFiscalYear.FiscalYearEnd;

                        ob.UpdatedBy = _VM_AccountFiscalYear.UpdatedBy;
                        ob.UpdatedOn = DateTime.UtcNow;
                        ob.IsDeleted = false;
                        _AccuteDbContext.AccountFiscalYears.Update(ob);
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
