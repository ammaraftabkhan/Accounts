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
    public class CivilEntitesLanguageRepository:ICivilEntitiesLanguageRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public CivilEntitesLanguageRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
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

            ob.IsDeleted = false;
            var LanguageId = _AccuteDbContext.Languages.Where(e => e.LanguageId == _VM_CivilEntitiesLanguage.LanguageId).FirstOrDefault();
            var CivilEntityId = _AccuteDbContext.CivilEntities.Where(e => e.CivilEntityId == _VM_CivilEntitiesLanguage.CivilEntityId).FirstOrDefault();
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

        public List<CivilEntitiesLanguage> GetCivilEntitiesLanguage()
        {
            try
            {
                var list = _AccuteDbContext.CivilEntitiesLanguages.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<CivilEntitiesLanguage>();
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
