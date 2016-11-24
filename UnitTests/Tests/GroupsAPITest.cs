using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace UnitTests.Tests
{
    [TestFixture]
    public class GroupsAPITest
    {
        private static GroupsAPI _groupsApi;
        private static SecurePassRestAPI _securePassRestApi;

        [OneTimeSetUp]
        public void InitializeTestClass()
        {
            _groupsApi = new GroupsAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
        }

        [Test]
        public void TestGroupList()
        {
            var groupsMemberReq = new GroupsListReq();
            var groupListResp = _groupsApi.groupsList(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupListResp.rc));
        }

        [Test]
        public void TestGroupAdd()
        {
            var groupAddReq =   new GroupAddReq();
            groupAddReq.GROUP = TestUtility.GroupTestName;
            groupAddReq.DESCRIPTION = TestUtility.GroupTestDescription;

            var resp = _groupsApi.groupsAdd(groupAddReq);
           Assert.IsTrue(TestUtility.checkIFResponseIsOK(resp.rc));
        }

        //  groupsMemberReq.USERNAME = TestUtility.GetTestUserName().USERNAME;
//            groupsMemberReq.GROUP = "PIPPO";

    }
}
