using Accounts.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Response_Model
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new Dictionary<string, string[]>();
            ErrorCombined = new Dictionary<int, string>();

            //PrivateErrors = new List<string>();
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }

        /// <summary>
        /// PublicErrors for end users
        /// </summary>
        public Dictionary<string, string[]>? Errors { get; set; }
        public Dictionary<int, string>? ErrorCombined { get; set; }
        /// 
        //public string? Error { get; set; }
        /// <summary>
        /// PrivateErrors that are api specifc
        /// </summary>
        //public List<string> PrivateErrors { get; set; }
        //public Exception? OriginalException { get; set; }
        //public string? CustomErrorMessage { get; set; }
        public int ErrorID { get; set; }
        public int StatusCode { get; set; }

        public void CreateSuccessResponse(HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = (int)statusCode;
            IsSuccess = true;
        }
        public void CreateErrorResponse(Exception? ex)
        {
            HttpStatusCode? statusCode = HttpStatusCode.ExpectationFailed;
            if (ex is EntityNotFoundException)
            {
                statusCode = HttpStatusCode.NotFound;
            }
            else
            {
            }
            StatusCode = (int)statusCode;
            IsSuccess = false;
            Errors!.Add(ex?.GetType().Name!, new string[] { ex?.Message! });
        }
    }
}
