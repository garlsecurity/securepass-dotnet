using System;
using System.Collections.Generic;

namespace SecurePass.DotNet.Class.PlainObject
{
    class Groups
    {
    }

    public class GroupIDReq : JSONBaseDataRequest
    {
        public string GROUP { get; set; }
    }

    public class GroupIDResp : JSONBaseDataResponse
    {
        public string GROUP { get; set; }
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
    public class GroupAddReq : GroupIDReq
    {
        public String DESCRIPTION { get; set; }
    }

    public class GruoupAddResp : JSONBaseDataResponse
    {
        public GroupIDReq GROUP;
    }

    //URL 'groups/delete'
    public class GroupDeleteReq : GroupIDReq
    {
    }

    public class GroupDeleteResp : JSONBaseDataResponse
    {

    }

    // ## MEMBERS OF GROUP OPERATION
    public class JSONUserNameAndGroup : GroupIDReq
    {
        public String USERNAME { get; set; }
    }


    // URL 'groups/members/check'
    public class GroupsMemberReq : JSONUserNameAndGroup
    {
    }

    public class GroupsMemberCheckResp : JSONBaseDataResponse
    {
        public bool member{ get; set; }
    }

    // URL 'groups/members/add'
    public class GroupsMemberAddResp : JSONBaseDataResponse
    {
    }

    //URL 'groups/members/delete'
    public class GroupsMembersDeleteResp : JSONBaseDataResponse
    {
    }

    // URL 'groups/members/list'
    public class GroupsMembersListResponse : JSONBaseDataResponse
    {
        public List<String> members { get; set; }

    }

}
