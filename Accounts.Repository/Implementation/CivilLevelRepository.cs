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
    public class CivilLevelRepository:ICivilLevelRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public CivilLevelRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }

        public bool AddCivilLevel(VM_CivilLevel _VM_CivilLevel)
        {
            CivilLevel ob = new CivilLevel();
            ob.CivilLevelName = _VM_CivilLevel.CivilLevelName;

            ob.CreatedOn = DateTime.UtcNow;
            ob.CreatedBy = _VM_CivilLevel.CreatedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.PostedBy= _VM_CivilLevel.PostedBy;

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

        public bool DeleteCivilLevel(int id)
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
                if (find != null && find.IsDeleted == false)
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

        public List<dynamic> GetAllCivilLevel(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.CivilLevels.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetCivilLevels", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;

            }
            catch
            {
                return new List<dynamic>();
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
                        data.CivilLevelName = _VM_CivilLevel.CivilLevelName;
                        data.UpdatedBy = _VM_CivilLevel.UpdatedBy;
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
