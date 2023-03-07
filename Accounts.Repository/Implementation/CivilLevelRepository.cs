﻿using Accounts.Common.Virtual_Models;
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
    public class CivilLevelRepository:ICivilLevelRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public CivilLevelRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool AddCivilLevel(VM_CivilLevel _VM_CivilLevel)
        {
            CivilLevel ob = new CivilLevel();
            ob.CivilLevelName = _VM_CivilLevel.CivilLevelName;

            ob.CivilLevelName = _VM_CivilLevel.CivilLevelName;
            ob.CreatedOn = DateTime.UtcNow;
            ob.CivilLevelName = _VM_CivilLevel.CivilLevelName;
            ob.PostedOn = DateTime.UtcNow;

            ob.IsDeleted = false;
            try
            {
                _AccuteDbContext.CivilLevels.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteCivilLevele(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilLevels.FirstOrDefault(e => e.CivilLevelId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.CivilLevels.Update(data);
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

        public CivilLevel FindCivilLevel(int id)
        {
            try
            {
                var find = _AccuteDbContext.CivilLevels.Find(id);
                if (find.IsDeleted == false)
                {
                    return find;
                }
                return new CivilLevel();

            }
            catch (Exception ex)
            {
                return new CivilLevel();
            }

            return new CivilLevel();
        }

        public List<CivilLevel> GetAllCivilLevel()
        {
            try
            {
                var list = _AccuteDbContext.CivilLevels.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<CivilLevel>();
            }
        }

        public bool UpdateCivilLevel(VM_CivilLevel _VM_CivilLevel)
        {
            if (_VM_CivilLevel.CivilLevelId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.CivilLevels.Find(_VM_CivilLevel.CivilLevelId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.CivilLevelId = _VM_CivilLevel.CivilLevelId;

                        data.UpdatedBy = _VM_CivilLevel.CivilLevelId;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.CivilLevels.Update(data);
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
