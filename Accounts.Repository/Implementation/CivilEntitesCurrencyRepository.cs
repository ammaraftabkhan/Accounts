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
    public class CivilEntitesCurrencyRepository:ICivilEntitesCurrencyRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public CivilEntitesCurrencyRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool AddCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrencye)
        {
            CivilEntitiesCurrency ob = new CivilEntitiesCurrency();
           ob.CivilEntityId = _VM_CivilEntitiesCurrencye.CivilEntityId;
            ob.CurrencyId = _VM_CivilEntitiesCurrencye.CurrencyId;
            ob.CivilEntityId = _VM_CivilEntitiesCurrencye.CivilEntityId;
            ob.CreatedOn = DateTime.UtcNow;
            ob.CivilEntityId = _VM_CivilEntitiesCurrencye.CivilEntityId;
            ob.PostedOn = DateTime.UtcNow;

            ob.IsDeleted = false;
            try
            {
                _AccuteDbContext.CivilEntitiesCurrencies.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteCivilEntitiesCurrency(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilEntitiesCurrencies.FirstOrDefault(e => e.CivilEntitiesCurrencyId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.CivilEntitiesCurrencies.Update(data);
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

        public CivilEntitiesCurrency FindCivilEntitesCurrency(int id)
        {
            try
            {
                var find = _AccuteDbContext.CivilEntitiesCurrencies.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new CivilEntitiesCurrency();

            }
            catch (Exception ex)
            {
                return new CivilEntitiesCurrency();
            }

            return new CivilEntitiesCurrency();
        }

        public List<CivilEntitiesCurrency> GetAllCivilEntitesCurrency()
        {
            try
            {
                var list = _AccuteDbContext.CivilEntitiesCurrencies.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<CivilEntitiesCurrency>();
            }
        }

        public bool UpdateCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrency)
        {
            if (_VM_CivilEntitiesCurrency.CivilEntitiesCurrencyId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilEntitiesCurrencies.Find(_VM_CivilEntitiesCurrency.CivilEntitiesCurrencyId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        
                        data.CurrencyId = _VM_CivilEntitiesCurrency.CurrencyId;
                        data.CivilEntityId = _VM_CivilEntitiesCurrency.CivilEntityId;
                        data.UpdatedBy = _VM_CivilEntitiesCurrency.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.CivilEntitiesCurrencies.Update(data);
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
