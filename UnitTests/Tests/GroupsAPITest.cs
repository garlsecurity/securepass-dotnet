using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace UnitTests.Tests
{
    [TestClass]
    public class GroupsAPITest
    {
        private static GroupsAPI _groupsApi;
        private static SecurePassRestAPI _securePassRestApi;

        [ClassInitialize()]
        public static void InitializeTestClass(TestContext context)
        {
            _groupsApi = new GroupsAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID, SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername, SecurePassTestAuth.SecurePassSecret);
        }

        [TestInitialize()]
        public void InitializeForEveryTest()
        {
        }

        [TestMethod]
        public void TestIsMemberOfGroup()
        {
            var groupsMemberReq = new GroupsMemberReq();
            groupsMemberReq.USERNAME = TestUtility.GetTestUserName().USERNAME;
            groupsMemberReq.GROUP = "PIPPO";
            var userIsMEmeberOf = _groupsApi.UserIsMEmeberOf(groupsMemberReq);
            Assert.IsTrue(TestUtility.checkIFResponseIsOK(userIsMEmeberOf.rc));
        }
    }
}
