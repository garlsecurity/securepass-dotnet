using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class GroupsAPI
    {
        public String groupsMemberAPIURL = "/api/v1/groups/member";

        public GroupsMemberResp UserIsMEmeberOf(GroupsMemberReq groupsMemberReq)
        {
            GroupsMemberResp groupsMemberResp= 
                SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberResp>(groupsMemberAPIURL, groupsMemberReq);

            return groupsMemberResp;
        }


    }
}
