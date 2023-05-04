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
    public class AddressTypeRpository : IAddressTypeRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AddressTypeRpository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAddressType(VM_AddressType _VM_AddressType)
        {
            AddressType ob = new AddressType();
            ob.Name = _VM_AddressType.Name;
            
            ob.CreatedBy = _VM_AddressType.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AddressType.PostedBy;
            ob.PostedOn = DateTime.UtcNow;

            try
            {
                _AccuteDbContext.AddressTypes.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAddressType(int id)
        {
            int? AddressTypeId = (int?)(_AccuteDbContext.Addresses.FirstOrDefault(e => e.AddressTypeId == id)?.AddressTypeId);
            if (id > 0 && id != AddressTypeId)
            {

                try
                {
                    var data = _AccuteDbContext.AddressTypes.FirstOrDefault(e => e.AddressTypeId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AddressTypes.Update(data);
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

        public AddressType FindAddressType(int id)
        {
            try
            {
                var find = _AccuteDbContext.AddressTypes.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AddressType();

            }
            catch (Exception ex)
            {
                return new AddressType();
            }

            return new AddressType();
        }

        public List<dynamic> GetAllAddressType(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.AddressTypes.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetAddressTypes", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAddressType(VM_AddressType _VM_AddressType)
        {
            if (_VM_AddressType.AddressTypeId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AddressTypes.Find(_VM_AddressType.AddressTypeId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.Name = _VM_AddressType.Name;
                        
                        data.UpdatedBy = _VM_AddressType.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AddressTypes.Update(data);
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
