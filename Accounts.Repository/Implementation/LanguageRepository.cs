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
    public class LanguageRepository:ILanguageRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public LanguageRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }

        public bool AddLanguage(VM_Language _VM_Language)
        {
            Language ob = new Language();
            ob.LanguageName = _VM_Language.LanguageName;
            ob.LanguageCode = _VM_Language.LanguageCode;

            ob.CreatedBy = _VM_Language.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_Language.PostedBy;
            ob.PostedOn = DateTime.UtcNow;

            ob.IsDeleted = false;
            try
            {
                _AccuteDbContext.Languages.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteLanguage(int id)
        {
            int? LanguageId = (int?)(_AccuteDbContext.CivilEntitiesLanguages.FirstOrDefault(e => e.LanguageId == id)?.LanguageId);

            if (id > 0 && id != LanguageId)
            {

                try
                {
                    var data = _AccuteDbContext.Languages.FirstOrDefault(e => e.LanguageId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.Languages.Update(data);
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

        public Language FindLanguage(int id)
        {
            try
            {
                var find = _AccuteDbContext.Languages.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new Language();

            }
            catch (Exception ex)
            {
                return new Language();
            }

            return new Language();
        }
    

        public List<dynamic> GetAllLanguage(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.Languages.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetLanguages", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateLanguage(VM_Language _VM_Language)
        {
            if (_VM_Language.LanguageId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.Languages.Find(_VM_Language.LanguageId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.LanguageName= _VM_Language.LanguageName;
                        data.LanguageCode= _VM_Language.LanguageCode;

                        data.UpdatedBy = _VM_Language.LanguageId;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.Languages.Update(data);
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
