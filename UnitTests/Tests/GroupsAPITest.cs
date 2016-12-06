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
            createTestGroup();

            GroupsListReq groupsListReq= new GroupsListReq();
            groupsListReq.REALM = TestUtility.realmTestName;
            var groupListResp = _groupsApi.groupsList(groupsListReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupListResp.rc));
            Assert.IsTrue(groupListResp.group.Contains(TestUtility.GroupTestName));
        }

        [Test]
        public void TestGroupAdd()
        {
            // Delete Test group if present
            deleteTestGroup();

            var resp = createTestGroup();
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(resp.rc));
        }

        private static GruoupAddResp createTestGroup()
        {
            var groupAddReq = new GroupAddReq();
            groupAddReq.GROUP = TestUtility.GroupTestName;
            groupAddReq.DESCRIPTION = TestUtility.GroupTestDescription;

            var resp = _groupsApi.groupsAdd(groupAddReq);
            return resp;
        }

        [Test]
        public void TestGroupDel()
        {
            var resp = deleteTestGroup();
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(resp.rc));
        }

        [Test]
        public void TestGroupMember()
        {
            // Create test user
            UserAPIClientTest apiClientTest = new UserAPIClientTest();
            apiClientTest.InitializeTestClass();
            apiClientTest.AddTestUserToRealm();

            GroupsMemberReq groupsMemberReq = new GroupsMemberReq();
            groupsMemberReq.GROUP = TestUtility.GroupTestName;
            groupsMemberReq.USERNAME = TestUtility.GetTestUserNameReq().USERNAME;

            // Add user to group
            var resp = _groupsApi.groupsMemberAdd(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(resp.rc));

            // Check if user is in group
            GroupsMemberCheckResp groupsMemberCheckResp = _groupsApi.groupsMemberCheck(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupsMemberCheckResp.rc));
            Assert.IsTrue(groupsMemberCheckResp.member );

            // Test if user is in list
            GroupIDReq req = new GroupIDReq();
            req.GROUP = TestUtility.GroupTestName;
            var groupsMembersListResponse = _groupsApi.groupsMembersList(req);
            Assert.IsTrue(groupsMembersListResponse.members.Contains(TestUtility.GetTestUserNameReq().USERNAME));

            //Delete user
            var groupsMembersDeleteResp = _groupsApi.groupsMemberDelete(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupsMembersDeleteResp.rc));

            // Test if user is deleted
            groupsMemberCheckResp = _groupsApi.groupsMemberCheck(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupsMemberCheckResp.rc));
            Assert.IsFalse(groupsMemberCheckResp.member);

        }



        // UTILITY METHOD
        private static GroupDeleteResp deleteTestGroup()
        {
            var groupDeleteReq = new GroupDeleteReq();
            groupDeleteReq.GROUP = TestUtility.GroupTestName;

            var resp = _groupsApi.groupsDelete(groupDeleteReq);
            return resp;
        }


        //  groupsMemberReq.USERNAME = TestUtility.GetTestUserNameReq().USERNAME;
//            groupsMemberReq.GROUP = "PIPPO";

    }
}
