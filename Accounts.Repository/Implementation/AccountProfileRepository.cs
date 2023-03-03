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
    public class AccountProfileRepository : IAccountProfileRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountProfileRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountProfile(int id, VM_AccountProfile _VM_AccountProfile)
        {
            //var getId = _AccuteDbContext.AccountProfiles.Any() ? _AccuteDbContext.AccountProfiles.Max(e => e.AcProfileId) + 1 : 1;
            //var AccountLedgerCode = _AccuteDbContext.AccountLedgers.Where(e => e.AcLedgerId == id).Select(e => e.AcLedgerCode).FirstOrDefault();
            AccountProfile ob = new AccountProfile();
            ob.BusinessName = _VM_AccountProfile.BusinessName;
            ob.ChqName = _VM_AccountProfile.ChqName;
            ob.Cell1 = _VM_AccountProfile.Cell1;
            ob.Cell2 = _VM_AccountProfile.Cell2;
            ob.Tel1 = _VM_AccountProfile.Tel1;
            ob.Tel2 = _VM_AccountProfile.Tel2;
            ob.Email = _VM_AccountProfile.Email;
            ob.Ntn = _VM_AccountProfile.Ntn;
            ob.Strn = _VM_AccountProfile.Strn;
            ob.CreatedBy = _VM_AccountProfile.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountProfile.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcLedgerId = Convert.ToInt64(id);
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
                _AccuteDbContext.AccountProfiles.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountProfile(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountProfiles.FirstOrDefault(e => e.AcProfileId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountProfiles.Update(data);
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

        public AccountProfile FindAccountProfile(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountProfiles.Find(id);
                if (find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountProfile();

            }
            catch (Exception ex)
            {
                return new AccountProfile();
            }
        
            return new AccountProfile();
        }

        public List<AccountProfile> GetAllAccountProfile()
        {
            try
            {
                var list = _AccuteDbContext.AccountProfiles.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountProfile>();
            }
        }

        public bool UpdateAccountProfile(VM_AccountProfile _VM_AccountProfile)
        {
            if (_VM_AccountProfile.AcProfileId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountProfiles.Find(_VM_AccountProfile.AcProfileId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.BusinessName= _VM_AccountProfile.BusinessName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.ChqName = _VM_AccountProfile.ChqName;
                        data.Cell1 = _VM_AccountProfile.Cell1;
                        data.Cell2 = _VM_AccountProfile.Cell2;
                        data.Tel1 = _VM_AccountProfile.Tel1;
                        data.Tel2 = _VM_AccountProfile.Tel2;
                        data.Email = _VM_AccountProfile.Email;
                        data.Ntn = _VM_AccountProfile.Ntn;
                        data.Strn = _VM_AccountProfile.Strn;
                        data.UpdatedBy = _VM_AccountProfile.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountProfiles.Update(data);
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
