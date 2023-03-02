using Accounts.Core.Context;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Repository.Implementation
{
    public class AccountHeadTypeRepository : IAccountHeadTypeRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        public AccountHeadTypeRepository(AccuteDbContext _AccuteDbContext)
        {
            this._AccuteDbContext = _AccuteDbContext;
        }

        public bool Add(VM_AccountHeadType _VM_AccountHeadType)
        {
            var headCode = _AccuteDbContext.AccountHeadTypes.Any() ? _AccuteDbContext.AccountHeadTypes.Max(e => e.AcHeadTypeId) + 1 : 1;
            AccountHeadType Ob =new AccountHeadType();
            Ob.AcHeadTypeName= _VM_AccountHeadType.AcHeadTypeName;
            Ob.CreatedBy= _VM_AccountHeadType.CreatedBy;
            Ob.CreatedOn = DateTime.UtcNow;
            Ob.PostedBy= _VM_AccountHeadType.PostedBy;
            Ob.PostedOn= DateTime.UtcNow;

           
            //Head Type Code Assignment

            Ob.AcHeadTypeCode = headCode.ToString();
           

            //if(headCode>9 && headCode < 100)
            //{

            //    Ob.AcHeadTypeCode = "0" + headCode.ToString();
            //}

            //if (headCode == 99)
            //{

            //    Ob.AcHeadTypeCode = headCode.ToString();
            //}
            



            try
            {
                _AccuteDbContext.AccountHeadTypes.Add(Ob);
                return  _AccuteDbContext.SaveChanges() > 0;
                
            }
            catch (Exception ex) 
            {
                return false;
            
            }
            
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                
                try
                {
                    var data = _AccuteDbContext.AccountHeadTypes.Find(id);
                    if(data != null && data.IsDeleted == false && data.IsActive == true)
                    {
                        data.IsActive = false;
                        data.IsDeleted = true;
                        _AccuteDbContext.AccountHeadTypes.Update(data);
                        return _AccuteDbContext.SaveChanges() > 0;
                    }
                    return false;
                  
                }
                catch(Exception ex) 
                { 
                    return false;
                }
            }

            return false;

        }

        public AccountHeadType Find(int id)
        {
            if (id > 0)
            {
                try
                {
                    var find = _AccuteDbContext.AccountHeadTypes.Find(id);
                    if (find.IsDeleted == false)
                    {
                        return find;
                    }
                    return new AccountHeadType();

                }
                catch (Exception ex)
                {
                    return new AccountHeadType();
                }
            }
            return new AccountHeadType();
           
        }
            
        public List <AccountHeadType> GetAccountHeadType()
        {
            try
            {
                var list = _AccuteDbContext.AccountHeadTypes.Where(e=>e.IsDeleted==false).ToList();
                
                return list;
            }
            catch (Exception ex)
            { 
                return new List<AccountHeadType>(); 
            }
            
        }

        public bool Update(VM_AccountHeadType _VM_AccountHeadType)
        {
            if(_VM_AccountHeadType.AcHeadTypeId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountHeadTypes.Find(_VM_AccountHeadType.AcHeadTypeId);
                    if (data != null && data.IsActive==true && data.IsDeleted==false)
                    {
                        data.AcHeadTypeName = _VM_AccountHeadType.AcHeadTypeName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountHeadType.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountHeadTypes.Update(data);
                        return _AccuteDbContext.SaveChanges() > 0;
                    }
                    return  false;
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
