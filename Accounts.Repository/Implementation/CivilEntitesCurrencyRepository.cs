using Accounts.Common.DataTable_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class CivilEntitesCurrencyRepository:ICivilEntitesCurrencyRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public CivilEntitesCurrencyRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }

        public bool AddCivilEntitiesCurrency(VM_CivilEntitiesCurrency _VM_CivilEntitiesCurrencye)
        {
            CivilEntitiesCurrency ob = new CivilEntitiesCurrency();
           ob.CivilEntityId = _VM_CivilEntitiesCurrencye.CivilEntityId;
            ob.CurrencyId = _VM_CivilEntitiesCurrencye.CurrencyId;
            
            ob.CreatedOn = DateTime.UtcNow;
            
            ob.PostedOn = DateTime.UtcNow;


            int? CurrencyId = _AccuteDbContext.Currencies.FirstOrDefault(e => e.CurrencyId == _VM_CivilEntitiesCurrencye.CurrencyId)?.CurrencyId;
            long? CivilEntityID = _AccuteDbContext.CivilEntities.FirstOrDefault(e => e.CivilEntityId == _VM_CivilEntitiesCurrencye.CivilEntityId)?.CivilEntityId;

            if (CurrencyId != null && CivilEntityID != null)
            {
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
            return false;
            
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

        public List<CivilEntitiesCurrency> GetAllCivilEntitesCurrency(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.CivilEntitiesCurrencies.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<CivilEntitiesCurrency>("GetCivilEntitiesCurrencies", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;


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
