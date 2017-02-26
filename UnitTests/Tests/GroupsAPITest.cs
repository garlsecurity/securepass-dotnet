using System;
using System.Collections.Generic;
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
            var groupListResp = GroupsAPI.GroupsList(groupsListReq);
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
            var resp = GroupsAPI.GroupsMemberAdd(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(resp.rc));

            // Check if user is in group
            GroupsMemberCheckResp groupsMemberCheckResp = GroupsAPI.GroupsMemberCheck(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupsMemberCheckResp.rc));
            Assert.IsTrue(groupsMemberCheckResp.member );

            // Test if user is in list
            GroupIDReq req = new GroupIDReq();
            req.GROUP = TestUtility.GroupTestName;
            var groupsMembersListResponse = GroupsAPI.GroupsMembersList(req);
            Assert.IsTrue(groupsMembersListResponse.members.Contains(TestUtility.GetTestUserNameReq().USERNAME));

            //Delete user
            var groupsMembersDeleteResp = GroupsAPI.GroupsMemberDelete(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupsMembersDeleteResp.rc));

            // Test if user is deleted
            groupsMemberCheckResp = GroupsAPI.GroupsMemberCheck(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(groupsMemberCheckResp.rc));
            Assert.IsFalse(groupsMemberCheckResp.member);

        }

        [Test]
        public void TestGroupXAttrs()
        {
            createTestGroup();
            GroupsXattrsSet groupsXattrsSet = getXAttrGroupTestSet();
            var jsonBaseDataResponse = _groupsApi.GroupsXattrsSet(groupsXattrsSet);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(jsonBaseDataResponse.rc));

            GroupsXattrsGet groupsXattrsGet = new GroupsXattrsGet();
            groupsXattrsGet.GROUP = TestUtility.GroupTestName;
            groupsXattrsGet.ATTRIBUTE = TestUtility.XattrNameTest;

            var xattrListResp = GroupsAPI.GroupsXattrsGet(groupsXattrsGet);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(xattrListResp.rc));
            Dictionary<String , String > keyValue = xattrListResp.values;
            String result;
            if (keyValue.TryGetValue(TestUtility.XattrNameTest, out result)) // Returns true.
            {
                Assert.IsTrue(result == TestUtility.XattrValueTest);
            }
            else
            {
                 Assert.Fail("Cannot found value in XATTR for key " + TestUtility.XattrNameTest );
            }

            var groupTestName = TestUtility.GroupTestName;
            GroupIDReq groupsXattrsListReq = new GroupIDReq();
            groupsXattrsListReq.GROUP = groupTestName;
            var groupsXattrsList = _groupsApi.GroupsXattrsList(groupsXattrsListReq);
            Assert.IsTrue(groupsXattrsList != null);
            // Seems a bug in the API?
            Assert.IsTrue(groupsXattrsList.values.Count == 1);

            xattrListResp = GroupsAPI.GroupsXattrsGet(groupsXattrsGet);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(xattrListResp.rc));
            keyValue = xattrListResp.values;
            if (keyValue.TryGetValue(TestUtility.XattrNameTest, out result)) // Returns true.
            {
                Assert.IsTrue(result == TestUtility.XattrValueTest);
            }
            else
            {
                Assert.Fail("Cannot found value in XATTR for key " + TestUtility.XattrNameTest );
            }

            GroupXattrDelete groupXattrDelete = new GroupXattrDelete();
            groupXattrDelete.GROUP = TestUtility.GroupTestName;
            groupXattrDelete.ATTRIBUTE = TestUtility.XattrNameTest;
            var deleteGroupsXattrs = _groupsApi.DeleteGroupsXattrs(groupXattrDelete);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(deleteGroupsXattrs.rc));

            xattrListResp = GroupsAPI.GroupsXattrsGet(groupsXattrsGet);

            // Attribute no more present we have an error
            Assert.IsFalse(TestUtility.checkIFResponseIsOK(xattrListResp.rc));

        }


        public static GruoupAddResp createTestGroup()
        {
            var groupAddReq = new GroupAddReq();
            groupAddReq.GROUP = TestUtility.GroupTestName;
            groupAddReq.DESCRIPTION = TestUtility.GroupTestDescription;

            var resp = GroupsAPI.GroupsAdd(groupAddReq);
            return resp;
        }


        private static GroupsXattrsSet getXAttrGroupTestSet()
        {
            GroupsXattrsSet groupXattrSetReq = new GroupsXattrsSet();
            groupXattrSetReq.GROUP = TestUtility.GroupTestName;
            groupXattrSetReq.ATTRIBUTE = TestUtility.XattrNameTest;
            groupXattrSetReq.VALUE = TestUtility.XattrValueTest;
            return groupXattrSetReq;
        }


        // UTILITY METHOD
        private static GroupDeleteResp deleteTestGroup()
        {
            var groupDeleteReq = new GroupIDReq();
            groupDeleteReq.GROUP = TestUtility.GroupTestName;

            var resp = GroupsAPI.GroupsDelete(groupDeleteReq);
            return resp;
        }


        //  groupsMemberReq.USERNAME = TestUtility.GetTestUserNameReq().USERNAME;
//            groupsMemberReq.GROUP = "PIPPO";

    }
}
