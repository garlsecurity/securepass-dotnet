using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace UnitTests.Tests
{
    [TestFixture]
    public class UserAPIClientTest
    {
        private String wrongUserName = "DFEREER#$cklfdadsfklsdfjlskdjflsdkjflsdfkj";

        private static SecurePassRestAPI _securePassRestApi;
        static UsersAPI _usersApi;
        static UserDataReq _testUserDataReq;



        [OneTimeSetUp]
        public  void InitializeTestClass()
        {
            _usersApi = new UsersAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
            _testUserDataReq = TestUtility.CreateTestUserObject();
        }

        [SetUp]
        public void InitializeForEveryTest()
        {
            DeleteTestUserFromRealm();
        }

        [TearDown]
        public void CleanupForEveryTest()
        {
            DeleteTestUserFromRealm();
        }


        private void DeleteTestUserFromRealm()
        {
            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();
            var response = _usersApi.deleteUSer(userNameReq);
        }


        // Utility Method for test
        public UserNameResp AddTestUserToRealm()
        {
            var userAdd = TestUtility.CreateTestUserObject();
            UserNameResp userName = _usersApi.addUser(userAdd);
            return userName;
        }

        // Utility Method for test
        private UserInfoResp GetTestUserInfoForTestUser()
        {
            UserNameReq testUsername = new UserNameReq();
            testUsername.USERNAME = TestUtility.GetTestUserNameReq().USERNAME;
            var result = _usersApi.GetUserInfo(testUsername);
            return result;
        }

        [Test]
        public void TestConstructor()
        {
            // TO DO  DO THIS !!
        }



        [Test]
        public void TestGetUserList()
        {
            AddTestUserToRealm();
            UserListResp result = _usersApi.GetUserList();

            Assert.IsTrue(result.Username.Count > 0);
            Assert.IsTrue(result.Username.Contains(TestUtility.GetTestUserNameReq().USERNAME));
            Assert.IsFalse(result.Username.Contains(wrongUserName));

        }


        [Test]
        public void TestAddUser()
        {
            var userName = AddTestUserToRealm();
            var rc = userName.rc;
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(rc));
        }



        [Test]
        public void TestDeleteUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();
            JSONBaseDataResponse response = (JSONBaseDataResponse)_usersApi.deleteUSer(userNameReq);

            Assert.IsTrue(response.rc == "0");
        }

        [Test]
        public void TestEnableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();
            JSONBaseDataResponse response = _usersApi.enableUSer(userNameReq);

            Assert.IsTrue(response.rc == "0");
            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == true);

        }

        [Test]
        public void TestDisableUser()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();

            JSONBaseDataResponse response = _usersApi.disableUSer(userNameReq);
            Assert.IsTrue(response.rc == "0");

            var testUserInfo = GetTestUserInfoForTestUser();
            Assert.IsTrue(testUserInfo.Enabled == false);
        }

        [Test]
        public void TestDisableUserPassowrd()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();

            JSONBaseDataResponse response = _usersApi.UserPasswordDisable(userNameReq);
            Assert.IsTrue(response.rc == "0");

        }

        [Test]
        public void TestDisableUserPassowrdChange()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();
            UserPasswordChangeReq userPasswordChangeReq = new UserPasswordChangeReq();
            userPasswordChangeReq.USERNAME = userNameReq.USERNAME;
            userPasswordChangeReq.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = _usersApi.UserPasswordChange(userPasswordChangeReq);
            Assert.IsTrue(response.rc == "0");

        }

        [Test]
        public void TestDisableUserPassowrdChangeWithBADUSER()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();
            UserPasswordChangeReq userPasswordChangeReq = new UserPasswordChangeReq();
            userPasswordChangeReq.USERNAME = userNameReq.USERNAME + "WWW";
            userPasswordChangeReq.PASSWORD = "ERT$%%^$%";

            JSONBaseDataResponse response = _usersApi.UserPasswordChange(userPasswordChangeReq);
            Assert.IsTrue(response.rc != "0");

        }

        [Test]
        public void TestgetUserXattrList()
        {
            // Prepare Test
            AddTestUserToRealm();

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();

            var userNameXattrSet = getXAttrUserTestSet();

            JSONBaseDataResponse responseXattrSet= _usersApi.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(responseXattrSet.rc == "0");


            XattrListResp response = _usersApi.UserXattrList(userNameReq);
            //Assert.IsTrue(response.rc == "0");

        }

        [Test]
        public void TestgetUserXattrSet()
        {
            // Prepare Test
            AddTestUserToRealm();

            var userNameXattrSet = getXAttrUserTestSet();

            JSONBaseDataResponse response = _usersApi.UserXattrSet(userNameXattrSet);
            Assert.IsTrue(response.rc == "0");

            UserNameReq userNameReq = TestUtility.GetTestUserNameReq();
            XattrListResp xattrListResp = _usersApi.UserXattrList(userNameReq);
            Assert.IsTrue(xattrListResp.rc == "0");
            Assert.IsTrue(xattrListResp.values[TestUtility.XattrNameTest] == TestUtility.XattrValueTest);

        }

        private static UserNameXattrSetReq getXAttrUserTestSet()
        {
            UserNameXattrSetReq userNameXattrSetReq = new UserNameXattrSetReq();
            userNameXattrSetReq.USERNAME = TestUtility.GetTestUserNameReq().USERNAME;
            userNameXattrSetReq.ATTRIBUTE = TestUtility.XattrNameTest;
            userNameXattrSetReq.VALUE = TestUtility.XattrValueTest;
            return userNameXattrSetReq;
        }


    }
}
