using Accounts.Common.DataTable_Model;
using Accounts.Common.Response_Model;
using Accounts.Common.Virtual_Models;
using Accounts.Core.Models;
using Accounts.Repository.Repository;
using Accounts.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Services.Implementation
{
    public class AccountControlServices : IAccountControlServices
    {
        private readonly IAccountControlRespository accountControlRespository;
        public AccountControlServices(IAccountControlRespository accountControlRespository)
        {
            this.accountControlRespository = accountControlRespository;
        }

        public bool AddAccountControl(VM_AccountControl _VM_AccountControl)
        {
            return accountControlRespository.AddAccountControl(_VM_AccountControl);
        }

        public ServiceResultDTO DeleteAccountControl(int id)
        {
            ServiceResultDTO serviceResult = new ServiceResultDTO();
            try
            {
                var response = accountControlRespository.DeleteAccountControl(id)
;
                if (!response)
                {
                    serviceResult?.Errors?.Add("RecordNotDelete", new string[] { "Record not success" });
                }
                else
                {
                    serviceResult = new ServiceResultDTO(new { msg = "Record delete succefully" });
                }

                return serviceResult!;
            }
            catch (Exception ex)
            {
                serviceResult.CreateErrorResponse(ex);
                return serviceResult;
            }
        }

        public AccountControl FindAccountControl(long id)
        {
            return accountControlRespository.FindAccountControl(id);
        }

        public ServiceResultDTO GetAllAccountControl(FilterModel filter)
        {
            ServiceResultDTO serviceResult = new ServiceResultDTO();
            try
            {
                var response = accountControlRespository.GetAllAccountControl(filter);
                serviceResult = new ServiceResultDTO(response);
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.CreateErrorResponse(ex);
                return serviceResult;
            }
        }
        public class BaseREsponse
        {
            public int? id { get; set; }
            public string? Message { get; set; }
        }
        public ServiceResultDTO UpdateAccountControl(VM_AccountControl _VM_AccountControl)
        {
            ServiceResultDTO serviceResult = new ServiceResultDTO();
            try
            {
                var response = accountControlRespository.UpdateAccountControl(_VM_AccountControl);
                if (response)
                {
                    serviceResult = new ServiceResultDTO(new BaseREsponse { Message = "Successfully updated" });
                }
                else
                {
                    serviceResult = new ServiceResultDTO(new { Msg = "Something went wrong X X X" });

                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                serviceResult.CreateErrorResponse(ex);
                return serviceResult;
            }
        }
    }
}
