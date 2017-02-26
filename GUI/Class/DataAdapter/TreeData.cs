using System;
using System.Collections.Generic;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace GUI
{
    public class TreeData
    {

        public static string[] ListGroup(String realmName)
        {
            GroupsListReq groupsListReq = new GroupsListReq();
            groupsListReq.REALM = realmName;
            var groupListResp = GroupsAPI.GroupsList(groupsListReq);
            return groupListResp.group.ToArray();
        }

        
    }
}