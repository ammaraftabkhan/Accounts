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
    public class AccountTransDetailRepository : IAccountTransDetailRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountTransDetailRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }
        public bool AddAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail)
        {
            AccountTransDetail ob = new AccountTransDetail();
            ob.AcTransMasterId = _VM_AccountTransDetail.AcTransMasterId;
            ob.PayeeAcContactId = _VM_AccountTransDetail.PayeeAcContactId;
            ob.PayeeAcLedgerId = _VM_AccountTransDetail.PayeeAcLedgerId;
            ob.PayeeAcSubLedgerId = _VM_AccountTransDetail.PayeeAcSubLedgerId;
            ob.PayeeRemarks = _VM_AccountTransDetail.PayeeRemarks;
            ob.ReceiverAcContactId = _VM_AccountTransDetail.ReceiverAcContactId;
            ob.ReceiverAcLedgerId = _VM_AccountTransDetail.ReceiverAcLedgerId;
            ob.ReceiverAcSubLedgerId = _VM_AccountTransDetail.ReceiverAcSubLedgerId;
            ob.ReceiverRemarks = _VM_AccountTransDetail.ReceiverRemarks;
            ob.ChqNum = _VM_AccountTransDetail.ChqNum;
            ob.ChqDate = _VM_AccountTransDetail.ChqDate;
            ob.CreatedBy = _VM_AccountTransDetail.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountTransDetail.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            try
            {
                _AccuteDbContext.AccountTransDetails.Add(ob);
                return _AccuteDbContext.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteAccountTransDetail(int id)
        {
            if (id > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransDetails.Find(id);
                    if (data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountTransDetails.Update(data);
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

        public AccountTransDetail FindAccountTransDetial(long id)
        {
            try
            {
                var find = _AccuteDbContext.AccountTransDetails.Find(id);
                if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountTransDetail();

            }
            catch (Exception ex)
            {
                return new AccountTransDetail();
            }

            return new AccountTransDetail();
        }

        public List<AccountTransDetail> GetAllAccountTransDetail()
        {
            try
            {
                var list = _AccuteDbContext.AccountTransDetails.Where(e => e.IsDeleted == false).ToList();

                return list;
            }
            catch
            {
                return new List<AccountTransDetail>();
            }
        }

        public bool UpdateAccountTransDetail(VM_AccountTransDetail _VM_AccountTransDetail)
        {
            if (_VM_AccountTransDetail.AcTransDetailId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountTransDetails.Find(_VM_AccountTransDetail.AcTransDetailId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {

                        data.AcTransMasterId = _VM_AccountTransDetail.AcTransMasterId;
                        data.PayeeAcContactId = _VM_AccountTransDetail.PayeeAcContactId;
                        data.PayeeAcLedgerId = _VM_AccountTransDetail.PayeeAcLedgerId;
                        data.PayeeAcSubLedgerId = _VM_AccountTransDetail.PayeeAcSubLedgerId;
                        data.PayeeRemarks = _VM_AccountTransDetail.PayeeRemarks;
                        data.ReceiverAcContactId = _VM_AccountTransDetail.ReceiverAcContactId;
                        data.ReceiverAcLedgerId = _VM_AccountTransDetail.ReceiverAcLedgerId;
                        data.ReceiverAcSubLedgerId = _VM_AccountTransDetail.ReceiverAcSubLedgerId;
                        data.ReceiverRemarks = _VM_AccountTransDetail.ReceiverRemarks;
                        data.UpdatedOn = DateTime.UtcNow;
                        data.UpdatedBy = _VM_AccountTransDetail.UpdatedBy;
                        _AccuteDbContext.AccountTransDetails.Update(data);
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
