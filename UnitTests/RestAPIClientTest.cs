using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using ClassLibrary1.Class;
using ClassLibrary1.Class.PlainObject;
using static System.Console;


namespace UnitTests
{
    [TestClass]
    public class RestAPIClientTest
    {
        private String wrongUserName = "DFEREER#$cklfdadsfklsdfjlskdjflsdkjflsdfkj";

        static APIClass apiClass;
        static UserData testUserData;


        private static string  XattrNameTest = "testattr";
        private static string XattrValueTest = "testAttrValue";


        private RestSharpClient restSharpClient;


        private static UserData CreateTestUserObject()
        {
            UserData userData = new UserData();
            userData.USERNAME = "testuser@wiran.net";
            userData.NAME = "test";
            userData.EMAIL = "test@test.com";
            userData.SURNAME = "TestSurname";
            userData.MOBILE = "+193356666666";
            return userData;
        }

        private static UserName GetTestUserName()
        {
            UserName userName = new UserName();
            userName.USERNAME = CreateTestUserObject().USERNAME;
            return userName;
        }

        [ClassInitialize()]
        public static void InitializeTestClass(TestContext context)
        {
            apiClass = new APIClass(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            testUserData = CreateTestUserObject();
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
            UserName userName = GetTestUserName();
            JSONBaseDataResponse response = apiClass.deleteUSer(userName);
        }


        // Utility Method for test
        private UserNameResponse AddTestUserToRealm()
        {
            var userAdd = CreateTestUserObject();
            UserNameResponse userName = apiClass.addUser(userAdd);
            return userName;
        }

        // Utility Method for test
        private UserInfo GetTestUserInfoForTestUser()
        {
            UserName testUsername = new UserName();
            testUsername.USERNAME = GetTestUserName().USERNAME;
            var result = apiClass.GetUserInfo(testUsername);
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
            UserList result = apiClass.GetUserList();

            Assert.IsTrue(result.Username.Count > 0);
            Assert.IsTrue(result.Username.Contains(GetTestUserName().USERNAME));
            Assert.IsFalse(result.Username.Contains(wrongUserName));

        }


        [TestMethod]
        public void TestAddUser()
        {
            var userName = AddTestUserToRealm();
            Assert.IsTrue(Int32.Parse(userName.rc) == 0);
        }


        [TestMethod]
        public void TestDeleteUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();
            JSONBaseDataResponse response = apiClass.deleteUSer(userName);

            Assert.IsTrue(response.rc == "0");
        }

        [TestMethod]
        public void TestEnableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();
            JSONBaseDataResponse response = apiClass.enableUSer(userName);

            Assert.IsTrue(response.rc == "0");
            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == true);

        }

        [TestMethod]
        public void TestDisableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();

            JSONBaseDataResponse response = apiClass.disableUSer(userName);
            Assert.IsTrue(response.rc == "0");

            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == false);
        }

        [TestMethod]
        public void TestDisableUserPassowrd()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();

            JSONBaseDataResponse response = apiClass.UserPasswordDisable(userName);
            Assert.IsTrue(response.rc == "0");

        }

        [TestMethod]
        public void TestDisableUserPassowrdChange()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();
            UserPasswordChange userPasswordChange = new UserPasswordChange();
            userPasswordChange.USERNAME = userName.USERNAME + "WWW";
            userPasswordChange.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = apiClass.UserPasswordChange(userPasswordChange);
            Assert.IsTrue(response.rc == "0");

        }

        [TestMethod]
        public void TestDisableUserPassowrdChangeWithBADUSER()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();
            UserPasswordChange userPasswordChange = new UserPasswordChange();
            userPasswordChange.USERNAME = userName.USERNAME + "WWW";
            userPasswordChange.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = apiClass.UserPasswordChange(userPasswordChange);
            Assert.IsTrue(response.rc != "0");

        }

        [TestMethod]
        public void TestgetUserXattrList()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserName userName = GetTestUserName();

            var userNameXattrSet = getXAttrTestSet();

            JSONBaseDataResponse responseXattrSet= apiClass.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(responseXattrSet.rc == "0");


            UserXattrList response = apiClass.UserXattrList(userName);
            //Assert.IsTrue(response.rc == "0");

        }



        [TestMethod]
        public void TestgetUserXattrSet()
        {
            // Prepare Test
            AddTestUserToRealm();

            var userNameXattrSet = getXAttrTestSet();

            JSONBaseDataResponse response = apiClass.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(response.rc == "0");

            UserName userName = GetTestUserName();
            UserXattrList userXattrList = apiClass.UserXattrList(userName);
            Assert.IsTrue(userXattrList.rc == "0");
            Assert.IsTrue(userXattrList.values[XattrNameTest] == XattrValueTest);

        }

        private static UserNameXattrSet getXAttrTestSet()
        {
            UserNameXattrSet userNameXattrSet = new UserNameXattrSet();
            userNameXattrSet.USERNAME = GetTestUserName().USERNAME;
            userNameXattrSet.ATTRIBUTE = XattrNameTest;
            userNameXattrSet.VALUE = XattrValueTest;
            return userNameXattrSet;
        }
    }
}
