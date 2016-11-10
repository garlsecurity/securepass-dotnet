using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using ClassLibrary1.Class;
using ClassLibrary1.Class.APIClass;
using ClassLibrary1.Class.PlainObject;
using UnitTests.Tests;
using static System.Console;


namespace UnitTests
{
    [TestClass]
    public class UserAPIClientTest
    {
        private String wrongUserName = "DFEREER#$cklfdadsfklsdfjlskdjflsdkjflsdfkj";

        private static SecurePassRestAPI _securePassRestApi;
        static UsersAPI _usersApi;
        static UserData testUserData;


        private static string  XattrNameTest = "testattr";
        private static string XattrValueTest = "testAttrValue";


        private SecurePassRestClient _securePassRestClient;


        [ClassInitialize()]
        public static void InitializeTestClass(TestContext context)
        {
            _usersApi = new UsersAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            testUserData = TestUtility.CreateTestUserObject();
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
            UserName userName = TestUtility.GetTestUserName();
            var response = _usersApi.deleteUSer(userName);
        }


        // Utility Method for test
        private UserNameResponse AddTestUserToRealm()
        {
            var userAdd = TestUtility.CreateTestUserObject();
            UserNameResponse userName = _usersApi.addUser(userAdd);
            return userName;
        }

        // Utility Method for test
        private UserInfo GetTestUserInfoForTestUser()
        {
            UserName testUsername = new UserName();
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
            UserList result = _usersApi.GetUserList();

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

            UserName userName = TestUtility.GetTestUserName();
            JSONBaseDataResponse response = (JSONBaseDataResponse)_usersApi.deleteUSer(userName);

            Assert.IsTrue(response.rc == "0");
        }

        [TestMethod]
        public void TestEnableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = TestUtility.GetTestUserName();
            JSONBaseDataResponse response = _usersApi.enableUSer(userName);

            Assert.IsTrue(response.rc == "0");
            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == true);

        }

        [TestMethod]
        public void TestDisableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = TestUtility.GetTestUserName();

            JSONBaseDataResponse response = _usersApi.disableUSer(userName);
            Assert.IsTrue(response.rc == "0");

            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == false);
        }

        [TestMethod]
        public void TestDisableUserPassowrd()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = TestUtility.GetTestUserName();

            JSONBaseDataResponse response = _usersApi.UserPasswordDisable(userName);
            Assert.IsTrue(response.rc == "0");

        }

        [TestMethod]
        public void TestDisableUserPassowrdChange()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = TestUtility.GetTestUserName();
            UserPasswordChange userPasswordChange = new UserPasswordChange();
            userPasswordChange.USERNAME = userName.USERNAME;
            userPasswordChange.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = _usersApi.UserPasswordChange(userPasswordChange);
            Assert.IsTrue(response.rc == "0");

        }

        [TestMethod]
        public void TestDisableUserPassowrdChangeWithBADUSER()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = TestUtility.GetTestUserName();
            UserPasswordChange userPasswordChange = new UserPasswordChange();
            userPasswordChange.USERNAME = userName.USERNAME + "WWW";
            userPasswordChange.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = _usersApi.UserPasswordChange(userPasswordChange);
            Assert.IsTrue(response.rc != "0");

        }

        [TestMethod]
        public void TestgetUserXattrList()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = TestUtility.GetTestUserName();

            var userNameXattrSet = getXAttrTestSet();

            JSONBaseDataResponse responseXattrSet= _usersApi.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(responseXattrSet.rc == "0");


            UserXattrList response = _usersApi.UserXattrList(userName);
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

            UserName userName = TestUtility.GetTestUserName();
            UserXattrList userXattrList = _usersApi.UserXattrList(userName);
            Assert.IsTrue(userXattrList.rc == "0");
            Assert.IsTrue(userXattrList.values[XattrNameTest] == XattrValueTest);

        }

        private static UserNameXattrSet getXAttrTestSet()
        {
            UserNameXattrSet userNameXattrSet = new UserNameXattrSet();
            userNameXattrSet.USERNAME = TestUtility.GetTestUserName().USERNAME;
            userNameXattrSet.ATTRIBUTE = XattrNameTest;
            userNameXattrSet.VALUE = XattrValueTest;
            return userNameXattrSet;
        }
    }
}
