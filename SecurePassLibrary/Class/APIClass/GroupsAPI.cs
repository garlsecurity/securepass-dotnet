using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class GroupsAPI
    {
        public String groupsListAPIURL = "groups/list";
        public String groupsAddPIURL = "groups/add";

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

    }
}
