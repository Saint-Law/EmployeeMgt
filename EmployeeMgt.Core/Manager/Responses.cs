using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMgt.Core.Manager
{
    public class Responses
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }

    public class Responses<T>: Responses 
    {
        public T data { get; set; }
    
    }


}
