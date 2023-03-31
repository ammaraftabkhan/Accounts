using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts.Common.Response_Model
{
    public class DataResponse
    {
        public dynamic data { get; set; }
        public int PageRecords { get; set; }
        //public int TotalRecords { get; set; }
    }
}
