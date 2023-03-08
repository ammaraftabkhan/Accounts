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
    public class CurrencyRepository:ICurrencyRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public CurrencyRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool AddCurrency(VM_Currency _VM_Currency)
        {
            Currency ob = new Currency();
            ob.CurrencyName = _VM_Currency.CurrencyName;
            ob.CurrencyCode = _VM_Currency.CurrencyCode;
            ob.CurrencySign = _VM_Currency.CurrencySign;
            ob.CreatedOn = DateTime.UtcNow;
            ob.CreatedBy = _VM_Currency.CreatedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_Currency.PostedBy;

            ob.IsDeleted = false;
            try
            {
                _AccuteDbContext.Currencies.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteCurrency(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.Currencies.FirstOrDefault(e => e.CurrencyId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.Currencies.Update(data);
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

        public Currency FindCurrency(int id)
        {
            try
            {
                var find = _AccuteDbContext.Currencies.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new Currency();

            }
            catch (Exception ex)
            {
                return new Currency();
            }

            return new Currency(); 
        }

        public List<Currency> GetAllCurrency()
        {
            try
            {
                var list = _AccuteDbContext.Currencies.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<Currency>();
            }
        }

        public bool UpdateCurrency(VM_Currency _VM_Currency)
        {
            if (_VM_Currency.CurrencyId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.Currencies.Find(_VM_Currency.CurrencyId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.CurrencyId = _VM_Currency.CurrencyId;
                        data.CurrencyCode = _VM_Currency.CurrencyCode;
                        data.CurrencyName = _VM_Currency.CurrencyName;
                        data.UpdatedBy = _VM_Currency.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.Currencies.Update(data);
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
