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
    public class AccountContactRopository : IAccountsContactRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountContactRopository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountContact(int id, VM_AccountContact _VM_AccountContact)
        {
            AccountContact ob = new AccountContact();
            ob.FirstName= _VM_AccountContact.FirstName;
            ob.LastName= _VM_AccountContact.LastName;
            ob.Position = _VM_AccountContact.Position;
            ob.Cell1 = _VM_AccountContact.Cell1;
            ob.Cell2 = _VM_AccountContact.Cell2;
            ob.Tel1 = _VM_AccountContact.Tel1;
            ob.Tel2 = _VM_AccountContact.Tel2;
            ob.Email = _VM_AccountContact.Email;
            ob.Ntn = _VM_AccountContact.Ntn;
            ob.Strn = _VM_AccountContact.Strn;
            ob.CreatedBy = _VM_AccountContact.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountContact.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcProfileId = Convert.ToInt64(id);
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
                _AccuteDbContext.AccountContacts.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountContact(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountContacts.FirstOrDefault(e => e.AcContactId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountContacts.Update(data);
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

        public AccountContact FindAccountContact(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountContacts.Find(id);
                if (find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountContact();

            }
            catch (Exception ex)
            {
                return new AccountContact();
            }

            return new AccountContact();
        }

        public List<AccountContact> GetAllAccountContact()
        {
            try
            {
                var list = _AccuteDbContext.AccountContacts.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountContact>();
            }
        }

        public bool UpdateAccountContact(VM_AccountContact _VM_AccountContact)
        {
            if (_VM_AccountContact.AcContactId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountContacts.Find(_VM_AccountContact.AcContactId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.FirstName= _VM_AccountContact.FirstName;
                        data.LastName = _VM_AccountContact.LastName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.Position = _VM_AccountContact.Position;
                        data.Cell1 = _VM_AccountContact.Cell1;
                        data.Cell2 = _VM_AccountContact.Cell2;
                        data.Tel1 = _VM_AccountContact.Tel1;
                        data.Tel2 = _VM_AccountContact.Tel2;
                        data.Email = _VM_AccountContact.Email;
                        data.Ntn = _VM_AccountContact.Ntn;
                        data.Strn = _VM_AccountContact.Strn;
                        data.UpdatedBy = _VM_AccountContact.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountContacts.Update(data);
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
