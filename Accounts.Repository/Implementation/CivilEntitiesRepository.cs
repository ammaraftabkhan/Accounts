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
    public class CivilEntitiesRepository:ICivilEntitiesRpository

    {
        private readonly AccuteDbContext _AccuteDbContext;
        public CivilEntitiesRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool AddACivilEntity(VM_CivilEntity _VM_CivilEntity)
        {
            CivilEntity ob = new CivilEntity();
            ob.CivilEntityName = _VM_CivilEntity.CivilEntityName;
            ob.CreatedBy = _VM_CivilEntity.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_CivilEntity.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.CivilLevelId = _VM_CivilEntity.CivilLevelId;
            ob.CivilParentId = _VM_CivilEntity.CivilParentId;
            ob.FlagImage = _VM_CivilEntity.FlagImage;

            int? CivilLevelId = _AccuteDbContext.CivilLevels.FirstOrDefault(e => e.CivilLevelId == _VM_CivilEntity.CivilLevelId)?.CivilLevelId;
            long? ParentId = _AccuteDbContext.CivilEntities.FirstOrDefault(e => e.CivilEntityId == _VM_CivilEntity.CivilParentId)?.CivilEntityId;

            if(CivilLevelId!=null && ParentId!=null)
            {
                try
                {
                    _AccuteDbContext.CivilEntities.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            
        }

        public bool DeleteCivilEntity(long id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilEntities.FirstOrDefault(e => e.CivilEntityId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.CivilEntities.Update(data);
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

        public CivilEntity FindCivilEntity(long id)
        {
            try
            {
                var find = _AccuteDbContext.CivilEntities.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new CivilEntity();

            }
            catch (Exception ex)
            {
                return new CivilEntity();
            }

            return new CivilEntity();
        }

        public List<CivilEntity> GetAllCivilEntity()
        {
            try
            {
                var list = _AccuteDbContext.CivilEntities.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<CivilEntity>();
            }
        }

        public bool UpdateCivilEntity(VM_CivilEntity _VM_CivilEntity)
        {
            if (_VM_CivilEntity.CivilEntityId > 0)
            {
                long? ParentId = _AccuteDbContext.CivilEntities.FirstOrDefault(e => e.CivilEntityId == _VM_CivilEntity.CivilParentId)?.CivilEntityId;
                if (ParentId!= null)
                {
                    try
                    {
                        var data = _AccuteDbContext.CivilEntities.Find(_VM_CivilEntity.CivilEntityId);
                        if (data != null && data.IsActive == true && data.IsDeleted == false)
                        {
                            data.CivilEntityName = _VM_CivilEntity.CivilEntityName;
                            data.FlagImage = _VM_CivilEntity.FlagImage;
                            data.CivilLevelId = _VM_CivilEntity.CivilLevelId;
                            data.CivilParentId = _VM_CivilEntity.CivilParentId;
                            data.UpdatedBy = _VM_CivilEntity.UpdatedBy;
                            data.UpdatedOn = DateTime.UtcNow;
                            _AccuteDbContext.CivilEntities.Update(data);
                            return _AccuteDbContext.SaveChanges() > 0;
                        }
                        return false;
                    }
                    catch
                    {
                        return false;
                    }
                }

                else
                {
                    return false;
                }

            }

            return false;
        }
    }
}
