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
    public class AddressRepository : IAddressRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AddressRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }
        public bool AddAddress(VM_Address _VM_Address)
        {
            Address ob = new Address();
            ob.AcContactId = _VM_Address.AcContactId;
            ob.AcProfileId= _VM_Address.AcProfileId;
            ob.AddressTypeId = _VM_Address.AddressTypeId;
            ob.CivilEntityId= _VM_Address.CivilEntityId;
            ob.Long= _VM_Address.Long;
            ob.Lat= _VM_Address.Lat;
            ob.Tag= _VM_Address.Tag;
            ob.Line1 = _VM_Address.Line1;
            ob.Line2 = _VM_Address.Line2;
            ob.Line3 = _VM_Address.Line3;
            ob.Line4= _VM_Address.Line4;
            ob.Line5= _VM_Address.Line5;
            ob.Note= _VM_Address.Note;
            ob.CreatedBy = _VM_Address.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_Address.PostedBy;
            ob.PostedOn = DateTime.UtcNow;

            long? ContactId = _AccuteDbContext.AccountContacts.FirstOrDefault(e => e.AcContactId ==  _VM_Address.AcContactId)?.AcContactId;
            long? ProfileId = _AccuteDbContext.AccountProfiles.FirstOrDefault(e => e.AcProfileId == _VM_Address.AcProfileId)?.AcProfileId;
            int? AddressTypeId = _AccuteDbContext.AddressTypes.FirstOrDefault(e => e.AddressTypeId == _VM_Address.AddressTypeId)?.AddressTypeId;
            long? CivilEntityId = _AccuteDbContext.CivilEntities.FirstOrDefault(e => e.CivilEntityId == _VM_Address.CivilEntityId)?.CivilEntityId;

            if (ContactId != null && ProfileId != null && AddressTypeId != null && CivilEntityId != null)
            {
                try
                {
                    _AccuteDbContext.Addresses.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }
            }
            return false;
            
        }

        public bool DeleteAddress(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.Addresses.FirstOrDefault(e => e.AddressId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.Addresses.Update(data);
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

        public Address FindAddress(int id)
        {
            try
            {
                var find = _AccuteDbContext.Addresses.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new Address();

            }
            catch (Exception ex)
            {
                return new Address();
            }

            return new Address();
        }

        public List<dynamic> GetAllAddress(FilterModel filter)
        {
            try
            {
                //var list = _AccuteDbContext.Addresses.Where(e => e.IsDeleted == false).ToList();

                //return list;


                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);

                db.Open();
                var data = db.Query<dynamic>("GetAddresses", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAddress(VM_Address _VM_Address)
        {
            if (_VM_Address.AddressId > 0)
            {

                try
                {
                    var ob = _AccuteDbContext.Addresses.Find(_VM_Address.AddressId);
                    if (ob != null && ob.IsActive == true && ob.IsDeleted == false)
                    {
                        ob.AcContactId = _VM_Address.AcContactId;
                        ob.AcProfileId = _VM_Address.AcProfileId;
                        ob.AddressTypeId = _VM_Address.AddressTypeId;
                        ob.CivilEntityId = _VM_Address.CivilEntityId;
                        ob.Long = _VM_Address.Long;
                        ob.Lat = _VM_Address.Lat;
                        ob.Tag = _VM_Address.Tag;
                        ob.Line1 = _VM_Address.Line1;
                        ob.Line2 = _VM_Address.Line2;
                        ob.Line3 = _VM_Address.Line3;
                        ob.Line4 = _VM_Address.Line4;
                        ob.Line5 = _VM_Address.Line5;
                        ob.Note = _VM_Address.Note;
                        ob.UpdatedBy = _VM_Address.UpdatedBy;
                        ob.UpdatedOn = DateTime.UtcNow;
                        ob.IsDeleted = false;
                        _AccuteDbContext.Addresses.Update(ob);
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
