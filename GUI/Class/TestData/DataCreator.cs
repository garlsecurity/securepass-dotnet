using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;
using UnitTests.Tests;

namespace GUI.TestData
{
    public class DataCreator
    {
        public static void createTestGroups(string realm)
        {
            for (int i = 0; i < 20; i++)
            {
                var groupDeleteReq = new GroupIDReq();
                GroupAddReq groupAddReq = new GroupAddReq();
                var @group = "GroupId " + i + realm;
                groupAddReq.GROUP = @group;
                groupAddReq.DESCRIPTION = "Group desc " + i;
                groupDeleteReq.GROUP = @group; 

                //var resp = GroupsAPI.GroupsDelete(groupDeleteReq);
                var gruoupAddResp = GroupsAPI.GroupsAdd(groupAddReq);
            }
        }
    }
}