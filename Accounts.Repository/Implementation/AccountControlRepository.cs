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
    public class AccountControlRepository : IAccountControlRespository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountControlRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountControl(int id, VM_AccountControl _VM_AccountControl)
        {
            var getId = _AccuteDbContext.AccountControls.Any() ? _AccuteDbContext.AccountControls.Max(e => e.AcControlId) + 1 : 1;
            var AccountHeadCode = _AccuteDbContext.AccountHeads.Where(e => e.AcHeadId == id).Select(e => e.AcHeadCode).FirstOrDefault();
            AccountControl ob = new AccountControl();
            ob.AcControlName = _VM_AccountControl.AcControlName;
            ob.CreatedBy = _VM_AccountControl.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountControl.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcHeadId =Convert.ToInt64(id);
            
            if (id < 10)
            {
                id.ToString();
                ob.AcControlCode = AccountHeadCode + "00" + getId.ToString();
            }
            else if (id < 100 && id > 9)
            {
                id.ToString();
                ob.AcControlCode = AccountHeadCode + "0" + getId.ToString();
            }
            else if (id < 1000 && id > 99)
            {
                id.ToString();
                ob.AcControlCode = AccountHeadCode + getId.ToString();
            }
            try
            {
                _AccuteDbContext.AccountControls.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

       

        public bool DeleteAccountControl(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountControls.FirstOrDefault(e => e.AcControlId == id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountControls.Update(data);
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

        public AccountControl FindAccountControl(long id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountControls.Find(id);
                    if (find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountControl();

                }
                catch (Exception ex)
                {
                    return new AccountControl();
                }
            }
            return new AccountControl();
        }

        public List<AccountControl> GetAllAccountControl()
        {
            try
            {
                return _AccuteDbContext.AccountControls.ToList();
            }
            catch
            {
                return new List<AccountControl>();
            }
        }

        public bool UpdateAccountControl(VM_AccountControl _VM_AccountControl)
        {
            if (_VM_AccountControl.AcControlId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountControls.Find(_VM_AccountControl.AcControlId);
                    if (data != null)
                    {
                        data.AcControlName = _VM_AccountControl.AcControlName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountControl.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountControls.Update(data);
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
