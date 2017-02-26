using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;
using Assert = NUnit.Framework.Assert;

namespace UnitTests.Tests
{
    [TestFixture]
    public class GenericUseTest
    {

        [Test]
        public void rightUse()
        {
            var _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            GroupsAPITest.createTestGroup();
            GroupsListReq groupsListReq= new GroupsListReq();
            groupsListReq.REALM = TestUtility.realmTestName;
            var groupListResp = GroupsAPI.GroupsList(groupsListReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupListResp.rc));
            Assert.IsTrue(groupListResp.group.Contains(TestUtility.GroupTestName));
        }

        [ExpectedException( typeof(NullReferenceException ))]
        public void badUse()
        {
            GroupsAPITest.createTestGroup();
            GroupsListReq groupsListReq= new GroupsListReq();
            groupsListReq.REALM = TestUtility.realmTestName;
            var groupListResp = GroupsAPI.GroupsList(groupsListReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupListResp.rc));
            Assert.IsTrue(groupListResp.group.Contains(TestUtility.GroupTestName));
        }


    }
}