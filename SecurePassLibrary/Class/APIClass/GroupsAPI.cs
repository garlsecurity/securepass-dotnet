using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class GroupsAPI
    {
        public String groupsListAPIURL = "groups/list";
        public String groupsAddPIURL = "groups/add";
        public String groupsDeleteURL = "groups/delete";

        public GroupListResp groupsList(GroupsListReq groupsListReq)
        {
            GroupListResp groupsMemberResp=
                SecurePassRestAPI.client.
                PostRequestWithParameter<GroupListResp>(groupsListAPIURL, groupsListReq);

            return groupsMemberResp;
        }

        public GruoupAddResp groupsAdd(GroupAddReq groupAddReq)
        {
            GruoupAddResp gruoupAddResp = SecurePassRestAPI.client.
                PostRequestWithParameter<GruoupAddResp>(groupsAddPIURL, groupAddReq);
            return gruoupAddResp;
        }

        public GroupDeleteResp groupsDelete(GroupDeleteReq req)
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

        public GroupsMemberCheckResp groupsMemberCheck(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberCheckResp>(groupsMemberCheckURL, req);
            return (GroupsMemberCheckResp) resp;
        }


        public GroupsMemberAddResp groupsMemberAdd(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberAddResp>(groupsMemberAddURL, req);
            return (GroupsMemberAddResp) resp;
        }

        public GroupsMembersDeleteResp groupsMemberDelete(GroupsMemberReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersDeleteResp>(groupsMemberDeleteURL, req);
            return (GroupsMembersDeleteResp) resp;
        }

        public GroupsMembersListResponse groupsMembersList(GroupIDReq req)
        {
            IJSONBaseDataResponse resp = SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMembersListResponse>(groupsMemberLisURL, req);
            return (GroupsMembersListResponse) resp;
        }


    }
}
