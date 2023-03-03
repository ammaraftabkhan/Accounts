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
    public class AddressTypeRpository : IAddressTypeRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AddressTypeRpository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAddressType(VM_AddressType _VM_AddressType)
        {
            AddressType ob = new AddressType();
            ob.Name = _VM_AddressType.Name;
            
            ob.CreatedBy = _VM_AddressType.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AddressType.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            
            ob.IsDeleted = false;

            //if (id < 10)
            //{
            //    id.ToString();
            //    ob.AcSubLedgerCode = AccountLedgerCode + "-00" + getId.ToString();
            //}
            //else if (id < 100 && id > 9)
            //{
            //    id.ToString();
            //    ob.AcSubLedgerCode = AccountLedgerCode + "-0" + getId.ToString();
            //}
            //else if (id < 1000 && id > 99)
            //{
            //    id.ToString();
            //    ob.AcSubLedgerCode = AccountLedgerCode + "-" + getId.ToString();
            //}
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
            if (id > 0)
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
                if (find.IsDeleted == false)
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

        public List<AddressType> GetAllAddressType()
        {
            try
            {
                var list = _AccuteDbContext.AddressTypes.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AddressType>();
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
