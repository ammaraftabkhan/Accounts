using Accounts.Common;
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
    public class AccountTransTypeRepository : IAccountTransTypeRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountTransTypeRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountTransType(VM_AccountTransType _VM_AccountTransType)
        {
            AccountTransType accountTransType = new AccountTransType();
            accountTransType.AcTransTypeName = _VM_AccountTransType.AcTransTypeName;
            accountTransType.CreatedBy = _VM_AccountTransType.CreatedBy;
            accountTransType.CreatedOn = DateTime.UtcNow;
            accountTransType.PostedBy = _VM_AccountTransType.PostedBy;
            accountTransType.PostedOn = DateTime.UtcNow;
            try
            {
                _AccuteDbContext.AccountTransTypes.Add(accountTransType);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountTransType(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransTypes.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountTransTypes.Update(data);
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

        public AccountTransType FindAccountTransType(int id)
        {
            try
            {
                var find = _AccuteDbContext.AccountTransTypes.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountTransType();

            }
            catch (Exception ex)
            {
                return new AccountTransType();
            }

            return new AccountTransType();
        }

        public List<AccountTransType> GetAllAccountTranstype()
        {
            try
            {
                var list = _AccuteDbContext.AccountTransTypes.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountTransType>();
            }
        }

        public bool UpdateAccountTransType(VM_AccountTransType _VM_AccountTransType)
        {
            if (_VM_AccountTransType.AcTransTypeId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransTypes.Find(_VM_AccountTransType.AcTransTypeId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        data.AcTransTypeName = _VM_AccountTransType.AcTransTypeName;
                        data.UpdatedBy = _VM_AccountTransType.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountTransTypes.Update(data);
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
