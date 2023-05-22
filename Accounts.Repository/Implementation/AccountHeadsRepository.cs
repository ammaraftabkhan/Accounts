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
    public class AccountHeadsRepository: IAccountHeadsRepository
    {
        private readonly AccuteDbContext _AccuteDbContext;
        private readonly IConfiguration configuration;
        public AccountHeadsRepository(AccuteDbContext _AccuteDbContext, IConfiguration configuration)
        {
            this._AccuteDbContext = _AccuteDbContext;
            this.configuration = configuration;
        }

        public bool AddAccountHead(VM_AccountHeads _VM_AccountHeads)
        {
            var getId = _AccuteDbContext.AccountHeads.Any() ? _AccuteDbContext.AccountHeads.Max(e => e.AcHeadId) + 1 : 1;
            var AccountHeadTypeCode = _AccuteDbContext.AccountHeadTypes.Where(e => e.AcHeadTypeId == _VM_AccountHeads.AcHeadTypeId).Select(e => e.AcHeadTypeCode).FirstOrDefault();
            AccountHead ob = new AccountHead();
            ob.AcHeadName = _VM_AccountHeads.AcHeadName;
            ob.CreatedBy = _VM_AccountHeads.CreatedBy;
            ob.CreatedOn = DateTime.UtcNow;
            ob.PostedBy = _VM_AccountHeads.PostedBy;
            ob.PostedOn = DateTime.UtcNow;
            ob.AcHeadTypeId = _VM_AccountHeads.AcHeadTypeId;

            int? HeadtypeID = _AccuteDbContext.AccountHeadTypes.FirstOrDefault(e => e.AcHeadTypeId == _VM_AccountHeads.AcHeadTypeId)?.AcHeadTypeId;
            if(HeadtypeID != null)
            {
                if (getId < 10)
                {

                    ob.AcHeadCode = AccountHeadTypeCode + "0" + getId.ToString();
                }

                else if (getId < 100 && getId > 9)
                {

                    ob.AcHeadCode = AccountHeadTypeCode + getId.ToString();
                }

                try
                {
                    _AccuteDbContext.AccountHeads.Add(ob);
                    return _AccuteDbContext.SaveChanges() > 0;

                }
                catch (Exception ex)
                {
                    return false;

                }

            }
            return false;
        }

        public bool DeleteAccountHead(int id)
        {
            int? HeadId = (int?)(_AccuteDbContext.AccountControls.FirstOrDefault(e => e.AcHeadId == id)?.AcHeadId);
            if (id > 0 && id != HeadId)
            {

                try
                {
                    
                    var data = _AccuteDbContext.AccountHeads.FirstOrDefault(e=>e.AcHeadId  == id);
                    if (data != null && data.IsDeleted==false && data.IsActive==true)
                    {
                        data.IsActive= false;
                        data.IsDeleted=true;
                        _AccuteDbContext.AccountHeads.Update(data);
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

        public AccountHead FindAccountHead(long id)
        {
            if (id > 0)
            {
                try
                { 
                var find = _AccuteDbContext.AccountHeads.Find(id);
                    //var ret = _AccuteDbContext.AccountHeadTypes.Find(find.AcHeadTypeId);
                    if (find != null && find.IsDeleted == false)
                {
                    return find;
                }
                return new AccountHead();

                }
                catch (Exception ex)
                {
                    return new AccountHead();
                }
            }
            return new AccountHead();
        }

        public List<dynamic> GetAccountHead(FilterModel filter)
        {
            try
            {

                //var list = _AccuteDbContext.AccountHeads.Where(e => e.IsDeleted == false).ToList();

                //return list;

                IDbConnection db = new SqlConnection(configuration.GetConnectionString("Accountsdb"));
                DynamicParameters dynamicParameters = new DynamicParameters();
               
                dynamicParameters.Add("@PageSize", filter.PageSize);
                dynamicParameters.Add("@PageNumber", filter.PageNumber);
                dynamicParameters.Add("@SortColumn", filter.SortColumn);
                dynamicParameters.Add("@SortOrder", filter.SortOrder);
                dynamicParameters.Add("@SearchTerm", filter.SearchTerm);
               
                db.Open();
                   var data= db.Query<dynamic>("GetAccountHead", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
                db.Close();

                return  data;
            }
            catch
            {
                return new List<dynamic>();
            }
        }

        public bool UpdateAccountHead(VM_AccountHeads _VM_AccountHeads)
        {
            if (_VM_AccountHeads.AcHeadId > 0)
            {

                try
                {
                    var data = _AccuteDbContext.AccountHeads.Find(_VM_AccountHeads.AcHeadId);
                    if (data != null && data.IsActive == true && data.IsDeleted == false)
                    {
                        data.AcHeadName = _VM_AccountHeads.AcHeadName;
                        //data.AcHeadTypeCode = _VM_AccountHeadType.AcHeadTypeCode;
                        data.UpdatedBy = _VM_AccountHeads.UpdatedBy;
                        data.UpdatedOn = DateTime.UtcNow;
                        _AccuteDbContext.AccountHeads.Update(data);
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
