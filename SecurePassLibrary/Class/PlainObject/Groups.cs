using System;
using System.Collections.Generic;

namespace SecurePass.DotNet.Class.PlainObject
{
    class Groups
    {
    }

    public class GroupID
    {
        public String GROUP { get; set; }
    }

//    public class GroupsMemberReq : JSONBaseDataRequest
//    {
//        public String USERNAME { get; set; }
//        public String GROUP { get; set; }
//
//    }
//
//    public class GroupsMemberResp : JSONBaseDataResponse
//    {
//        public string MEMBER { get; set; }
//    }

    // URL 'groups/list'
    public class GroupsListReq : JSONBaseDataRequest
    {
        public string REALM { get; set; }
    }

    public class GroupListResp : JSONBaseDataResponse
    {
        public List<String> group { get; set; }
    }

    //URL 'groups/add'
    public class GroupAddReq : JSONBaseDataRequest
    {
        public String GROUP { get; set; }
        public String DESCRIPTION { get; set; }
    }

    public class GruoupAddResp : JSONBaseDataResponse
    {
        public string GROUP { get; set; }
    }

}
