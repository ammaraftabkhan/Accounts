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
    public class CurrencyRepository:ICurrencyRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public CurrencyRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
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
            int? CurrencyId = (int?)(_AccuteDbContext.CivilEntitiesCurrencies.FirstOrDefault(e => e.CurrencyId == id)?.CurrencyId);

            if (id > 0 && id != CurrencyId)
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

        public List<dynamic> GetAllCurrency(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.Currencies.Where(e => e.IsDeleted == false).ToList();

                //return list;
                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetCurrencies", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
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
