using System;

namespace SecurePass.DotNet.Class.PlainObject
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
