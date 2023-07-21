using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Response_Model
{
    public interface IErrorResponse
    {
        public bool IsSuccess { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }
        //public string? Error { get; set; }

    }
}
