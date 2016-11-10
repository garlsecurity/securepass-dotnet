using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurePass.DotNet.Class;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace UnitTests.Tests
{
    [TestClass]
    public class UserAPIClientTest
    {
        private String wrongUserName = "DFEREER#$cklfdadsfklsdfjlskdjflsdkjflsdfkj";

        private static SecurePassRestAPI _securePassRestApi;
        static UsersAPI _usersApi;
        static UserDataReq _testUserDataReq;


        private static string  XattrNameTest = "testattr";
        private static string XattrValueTest = "testAttrValue";

        [ClassInitialize()]
        public static void InitializeTestClass(TestContext context)
        {
            _usersApi = new UsersAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            _testUserDataReq = TestUtility.CreateTestUserObject();
        }

        [TestInitialize()]
        public void InitializeForEveryTest()
        {
            DeleteTestUserFromRealm();
        }

        [TestCleanup]
        public void CleanupForEveryTest()
        {
            DeleteTestUserFromRealm();
        }


        private void DeleteTestUserFromRealm()
        {
            UserNameReq userNameReq = TestUtility.GetTestUserName();
            var response = _usersApi.deleteUSer(userNameReq);
        }


        // Utility Method for test
        private UserNameResp AddTestUserToRealm()
        {
            var userAdd = TestUtility.CreateTestUserObject();
            UserNameResp userName = _usersApi.addUser(userAdd);
            return userName;
        }

        // Utility Method for test
        private UserInfoResp GetTestUserInfoForTestUser()
        {
            UserNameReq testUsername = new UserNameReq();
            testUsername.USERNAME = TestUtility.GetTestUserName().USERNAME;
            var result = _usersApi.GetUserInfo(testUsername);
            return result;
        }

        [TestMethod]
        public void TestConstructor()
        {
            // TO DO  DO THIS !!
        }



        [TestMethod]
        public void TestGetUserList()
        {
            AddTestUserToRealm();
            UserListResp result = _usersApi.GetUserList();

            Assert.IsTrue(result.Username.Count > 0);
            Assert.IsTrue(result.Username.Contains(TestUtility.GetTestUserName().USERNAME));
            Assert.IsFalse(result.Username.Contains(wrongUserName));

        }


        [TestMethod]
        public void TestAddUser()
        {
            var userName = AddTestUserToRealm();
            var rc = userName.rc;
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(rc));
        }



        [TestMethod]
        public void TestDeleteUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();
            JSONBaseDataResponse response = (JSONBaseDataResponse)_usersApi.deleteUSer(userNameReq);

            Assert.IsTrue(response.rc == "0");
        }

        [TestMethod]
        public void TestEnableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();
            JSONBaseDataResponse response = _usersApi.enableUSer(userNameReq);

            Assert.IsTrue(response.rc == "0");
            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == true);

        }

        [TestMethod]
        public void TestDisableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();

            JSONBaseDataResponse response = _usersApi.disableUSer(userNameReq);
            Assert.IsTrue(response.rc == "0");

            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == false);
        }

        [TestMethod]
        public void TestDisableUserPassowrd()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();

            JSONBaseDataResponse response = _usersApi.UserPasswordDisable(userNameReq);
            Assert.IsTrue(response.rc == "0");

        }

        [TestMethod]
        public void TestDisableUserPassowrdChange()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();
            UserPasswordChangeReq userPasswordChangeReq = new UserPasswordChangeReq();
            userPasswordChangeReq.USERNAME = userNameReq.USERNAME;
            userPasswordChangeReq.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = _usersApi.UserPasswordChange(userPasswordChangeReq);
            Assert.IsTrue(response.rc == "0");

        }

        [TestMethod]
        public void TestDisableUserPassowrdChangeWithBADUSER()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();
            UserPasswordChangeReq userPasswordChangeReq = new UserPasswordChangeReq();
            userPasswordChangeReq.USERNAME = userNameReq.USERNAME + "WWW";
            userPasswordChangeReq.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = _usersApi.UserPasswordChange(userPasswordChangeReq);
            Assert.IsTrue(response.rc != "0");

        }

        [TestMethod]
        public void TestgetUserXattrList()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserName();

            var userNameXattrSet = getXAttrTestSet();

            JSONBaseDataResponse responseXattrSet= _usersApi.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(responseXattrSet.rc == "0");


            UserXattrListResp response = _usersApi.UserXattrList(userNameReq);
            //Assert.IsTrue(response.rc == "0");

        }



        [TestMethod]
        public void TestgetUserXattrSet()
        {
            // Prepare Test
            AddTestUserToRealm();

            var userNameXattrSet = getXAttrTestSet();

            JSONBaseDataResponse response = _usersApi.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(response.rc == "0");

            UserNameReq userNameReq = TestUtility.GetTestUserName();
            UserXattrListResp userXattrListResp = _usersApi.UserXattrList(userNameReq);
            Assert.IsTrue(userXattrListResp.rc == "0");
            Assert.IsTrue(userXattrListResp.values[XattrNameTest] == XattrValueTest);

        }

        private static UserNameXattrSetReq getXAttrTestSet()
        {
            UserNameXattrSetReq userNameXattrSetReq = new UserNameXattrSetReq();
            userNameXattrSetReq.USERNAME = TestUtility.GetTestUserName().USERNAME;
            userNameXattrSetReq.ATTRIBUTE = XattrNameTest;
            userNameXattrSetReq.VALUE = XattrValueTest;
            return userNameXattrSetReq;
        }
    }
}
