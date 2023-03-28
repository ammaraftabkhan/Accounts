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
    public class CivilEntitesLanguageRepository:ICivilEntitiesLanguageRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public CivilEntitesLanguageRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }

        public bool AddCivilEntitiesLanguage(VM_CivilEntitiesLanguage _VM_CivilEntitiesLanguage)
        {
            CivilEntitiesLanguage ob = new CivilEntitiesLanguage();
            ob.LanguageId = _VM_CivilEntitiesLanguage.LanguageId;
            ob.CivilEntityId = _VM_CivilEntitiesLanguage.CivilEntityId;
            ob.CreatedBy = _VM_CivilEntitiesLanguage.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_CivilEntitiesLanguage.PostedBy;
            ob.PostedOn = DateTime.UtcNow;


            int? LanguageId = _AccuteDbContext.Languages.FirstOrDefault(e => e.LanguageId == _VM_CivilEntitiesLanguage.LanguageId)?.LanguageId;
            long? CivilEntityId = _AccuteDbContext.CivilEntities.FirstOrDefault(e => e.CivilEntityId == _VM_CivilEntitiesLanguage.CivilEntityId)?.CivilEntityId;

            if(LanguageId != null && CivilEntityId != null)
            {
                try
                {
                    _AccuteDbContext.CivilEntitiesLanguages.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            return false;
        }

        public bool DeleteCivilEntitiesLanguage(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilEntitiesLanguages.FirstOrDefault(e => e.CivilEntitiessLanguagesId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.CivilEntitiesLanguages.Update(data);
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

        public CivilEntitiesLanguage FindCivilEntitiesLanguage(int id)
        {
            try
            {
                var find = _AccuteDbContext.CivilEntitiesLanguages.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new CivilEntitiesLanguage();

            }
            catch (Exception ex)
            {
                return new CivilEntitiesLanguage();
            }

            return new CivilEntitiesLanguage();
        }

        public List<dynamic> GetCivilEntitiesLanguage(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.CivilEntitiesLanguages.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetCivilEntitiesLanguage", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateCivilEntitiesLanguage(VM_CivilEntitiesLanguage _VM_CivilEntitiesLanguage)
        {
            if (_VM_CivilEntitiesLanguage.CivilEntitiessLanguagesId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilEntitiesLanguages.Find(_VM_CivilEntitiesLanguage.CivilEntitiessLanguagesId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.LanguageId = _VM_CivilEntitiesLanguage.LanguageId;
                        data.CivilEntityId = _VM_CivilEntitiesLanguage.CivilEntityId;
                        data.UpdatedBy = _VM_CivilEntitiesLanguage.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.CivilEntitiesLanguages.Update(data);
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
