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
    public class AddressRepository : IAddressRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AddressRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
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
            ob.IsDeleted = false;

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

        public List<Address> GetAllAddress()
        {
            try
            {
                var list = _AccuteDbContext.Addresses.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<Address>();
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
