using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Class.PlainObject;

namespace ClassLibrary1.Class.APIClass
{
    public class GroupsAPI
    {
        public String groupsMemberAPIURL = "/api/v1/groups/member";
        private readonly SecurePassRestAPI _securePassRestApi;

        public GroupsMemberResp UserIsMEmeberOf(GroupsMemberReq groupsMemberReq)
        {
            GroupsMemberResp groupsMemberResp= 
                SecurePassRestAPI.client.
                PostRequestWithParameter<GroupsMemberResp>(groupsMemberAPIURL, groupsMemberReq);

            return groupsMemberResp;
        }


    }
}
