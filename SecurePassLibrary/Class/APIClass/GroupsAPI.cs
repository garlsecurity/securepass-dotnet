using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class GroupsAPI
    {
        public String groupsListAPIURL = "groups/list";
        public String groupsAddPIURL = "groups/add";
        public String groupsDeleteURL = "groups/delete";

        public GroupListResp GroupsList(GroupsListReq groupsListReq)
        {
            GroupListResp groupsMemberResp=
                SecurePassRestAPI.client.
                PostRequestWithParameter<GroupListResp>(groupsListAPIURL, groupsListReq);

            return groupsMemberResp;
        }

        public GruoupAddResp GroupsAdd(GroupAddReq groupAddReq)
        {
            GruoupAddResp gruoupAddResp = SecurePassRestAPI.client.
                PostRequestWithParameter<GruoupAddResp>(groupsAddPIURL, groupAddReq);
            return gruoupAddResp;
        }

        public GroupDeleteResp GroupsDelete(GroupIDReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupDeleteResp>(groupsDeleteURL, req);
            return (GroupDeleteResp) resp;
        }


        // ## USER MEMBER GROUP OPERATION
        public string groupsMemberAddURL = "groups/members/add";
        public string groupsMemberCheckURL = "groups/members/check";
        public string groupsMemberDeleteURL = "groups/members/delete";
        public string groupsMemberLisURL = "groups/members/list";

        public GroupsMemberCheckResp GroupsMemberCheck(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberCheckResp>(groupsMemberCheckURL, req);
            return (GroupsMemberCheckResp) resp;
        }


        public GroupsMemberAddResp GroupsMemberAdd(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberAddResp>(groupsMemberAddURL, req);
            return (GroupsMemberAddResp) resp;
        }

        public GroupsMembersDeleteResp GroupsMemberDelete(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersDeleteResp>(groupsMemberDeleteURL, req);
            return (GroupsMembersDeleteResp) resp;
        }

        public GroupsMembersListResponse GroupsMembersList(GroupIDReq req)
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
        public string groupXattrsList = "groups/xattrs/list";
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
        public string groupXattrsDelete = "groups/xattrs/delete";
        public JSONBaseDataResponse DeleteGroupsXattrs(GroupXattrDelete req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<JSONBaseDataResponse>(groupXattrsDelete, req);
            return (JSONBaseDataResponse) resp;
        }




        public string groupXattrsSetURL = "groups/xattrs/set";
        public JSONBaseDataResponse GroupsXattrsSet(GroupsXattrsSet req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersListResponse>(groupXattrsSetURL, req);
            return (JSONBaseDataResponse) resp;
        }

        public string groupXattrGetURL = "groups/xattrs/get";
        public XattrListResp GroupsXattrsGet(GroupsXattrsGet req)
        {
            String response = SecurePassRestAPI.client.PostRequestWithParameter( groupXattrGetURL, req);

            var xattrListResp = XAttrs.GetXattrsValue(response);

            return xattrListResp;
        }

    }

}
