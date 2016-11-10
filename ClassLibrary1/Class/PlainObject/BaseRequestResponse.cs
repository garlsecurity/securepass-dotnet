using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Class.PlainObject
{

    public interface IJSONBaseDataResponse
    {
         string rc { get; set; }
         string errorMsg { get; set; }
    }

    public class JSONBaseDataResponse : IJSONBaseDataResponse
    {
        public  string rc { get; set; }
        public string errorMsg { get; set; }
    }

    public class JSONBaseDataRequest
    {
    }


}
