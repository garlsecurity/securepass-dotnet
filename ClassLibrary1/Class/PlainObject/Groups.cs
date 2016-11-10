using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Class.PlainObject
{
    class Groups
    {
    }

    public class GroupsMemberReq : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
        public String GROUP { get; set; }
    }

    public class GroupsMemberResp : JSONBaseDataResponse
    {
        public string MEMBER { get; set; }
    }

}
