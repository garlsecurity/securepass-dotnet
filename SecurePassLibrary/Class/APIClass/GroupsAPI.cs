using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class GroupsAPI
    {
        public static String groupsListAPIURL = "groups/list";
        public static String groupsAddPIURL = "groups/add";
        public static String groupsDeleteURL = "groups/delete";

        public static GroupListResp GroupsList(GroupsListReq groupsListReq)
        {
            GroupListResp groupsMemberResp=
                SecurePassRestAPI.client.
                PostRequestWithParameter<GroupListResp>(groupsListAPIURL, groupsListReq);

            return groupsMemberResp;
        }

        public static GruoupAddResp GroupsAdd(GroupAddReq groupAddReq)
        {
            GruoupAddResp gruoupAddResp = SecurePassRestAPI.client.
                PostRequestWithParameter<GruoupAddResp>(groupsAddPIURL, groupAddReq);
            return gruoupAddResp;
        }

        public static GroupDeleteResp GroupsDelete(GroupIDReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupDeleteResp>(groupsDeleteURL, req);
            return (GroupDeleteResp) resp;
        }


        // ## USER MEMBER GROUP OPERATION
        public static string groupsMemberAddURL = "groups/members/add";
        public static string groupsMemberCheckURL = "groups/members/check";
        public static string groupsMemberDeleteURL = "groups/members/delete";
        public static string groupsMemberLisURL = "groups/members/list";

        public static GroupsMemberCheckResp GroupsMemberCheck(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberCheckResp>(groupsMemberCheckURL, req);
            return (GroupsMemberCheckResp) resp;
        }


        public static GroupsMemberAddResp GroupsMemberAdd(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberAddResp>(groupsMemberAddURL, req);
            return (GroupsMemberAddResp) resp;
        }

        public static GroupsMembersDeleteResp GroupsMemberDelete(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersDeleteResp>(groupsMemberDeleteURL, req);
            return (GroupsMembersDeleteResp) resp;
        }

        public static GroupsMembersListResponse GroupsMembersList(GroupIDReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersListResponse>(groupsMemberLisURL, req);
            return (GroupsMembersListResponse) resp;
        }

//        URL 'groups/xattrs/list'	4
//        URL 'groups/xattrs/get'	4
//        URL 'groups/xattrs/set'	4
//        URL 'groups/xattrs/delete'	5


//        URL 'groups/xattrs/list'
//        """
//        Get the attributes of a given group
//
//            INPUT:
//        GROUP (required) -> Group ID
//
//        OUTPUT:
//        attributes/value pair in json
//            rc and errorMsg are reserved words!
//
        public static string groupXattrsList = "groups/xattrs/list";
        public XattrListResp GroupsXattrsList(GroupIDReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<XattrListResp>(groupXattrsList, req);
            return (XattrListResp) resp;
        }



//        URL 'groups/xattrs/delete'
//        """
//        Delete an attribute to a given group
//
//            INPUT:
//        GROUP (required)     -> Group ID
//        ATTRIBUTE (required) -> Attribute name
//
//        OUTPUT:
//        none
//
//        """
        public static string groupXattrsDelete = "groups/xattrs/delete";
        public JSONBaseDataResponse DeleteGroupsXattrs(GroupXattrDelete req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<JSONBaseDataResponse>(groupXattrsDelete, req);
            return (JSONBaseDataResponse) resp;
        }




        public static string groupXattrsSetURL = "groups/xattrs/set";
        public JSONBaseDataResponse GroupsXattrsSet(GroupsXattrsSet req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersListResponse>(groupXattrsSetURL, req);
            return (JSONBaseDataResponse) resp;
        }

        public static string groupXattrGetURL = "groups/xattrs/get";
        public static XattrListResp GroupsXattrsGet(GroupsXattrsGet req)
        {
            String response = SecurePassRestAPI.client.PostRequestWithParameter( groupXattrGetURL, req);

            var xattrListResp = XAttrs.GetXattrsValue(response);

            return xattrListResp;
        }

    }

}
