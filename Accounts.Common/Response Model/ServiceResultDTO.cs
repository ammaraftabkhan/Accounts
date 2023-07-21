using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Response_Model
{
    public class ServiceResultDTO : ErrorResponse
    {
        public dynamic? Result { get; protected set; }

        public ServiceResultDTO()
        {
        }

        public ServiceResultDTO(dynamic result, bool isSuccess = true)
        {
            Result = result;
            IsSuccess = isSuccess;
            StatusCode = (int)HttpStatusCode.OK;
        }
    }
}
