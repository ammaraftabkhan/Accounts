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
    public class LanguageRepository:ILanguageRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public LanguageRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool AddLanguage(VM_Language _VM_Language)
        {
            Language ob = new Language();
            ob.LanguageName = _VM_Language.LanguageName;

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
            if (id > 0)
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
                if (find.IsDeleted == false)
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
    

        public List<Language> GetAllLanguage()
        {
            try
            {
                var list = _AccuteDbContext.Languages.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<Language>();
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
                        _VM_Language.LanguageId = _VM_Language.LanguageId;

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
