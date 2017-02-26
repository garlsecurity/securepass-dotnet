using System;
using System.Text;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SecurePass.DotNet.Class.APIClass;
using SecurePass.DotNet.Class.PlainObject;

namespace UnitTests.Tests
{
    /// <summary>
    /// Summary description for AppsAPITest
    /// </summary>
    [TestFixture]
    public class AppsAPITest
    {
        public AppsAPITest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private static AppsAPI _appsApi;
        private static SecurePassRestAPI _securePassRestApi;

        [OneTimeSetUp]
        public void InitializeTestClass()
        {
            _appsApi = new AppsAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID,
                SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername,
                SecurePassTestAuth.SecurePassSecret);
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [Test]
        public void TestAppsDelete()
        {
            var request = TestUtility.AppsAddReq();
            AppsAddDataResp appsAddDataResp = _appsApi.addApps(request);
            String appId = appsAddDataResp.app_id;

            AppsDeleteReq appsDeleteReq = new AppsDeleteReq();
            appsDeleteReq.APP_ID = appId;

            var jsonBaseDataResponse = _appsApi.deleteApps(appsDeleteReq);
            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(jsonBaseDataResponse.rc);
            Assert.IsTrue(checkIfResponseIsOk);

        }

        [Test]
        public void TestAppsAdd()
        {
            var request = TestUtility.AppsAddReq();
            AppsAddDataResp appsAddDataResp = _appsApi.addApps(request);
            Assert.IsTrue(appsAddDataResp.rc == "0");
        }

        [Test]
        public void TestAppsInfo()
        {
            var request = TestUtility.AppsAddReq();
            AppsAddDataResp appsAddDataResp = _appsApi.addApps(request);
            String appId = appsAddDataResp.app_id;


            AppsInfoReq appsInfoReq = new AppsInfoReq();
            appsInfoReq.APP_ID = appId;
            var appsInfoResp = _appsApi.info(appsInfoReq);
            Assert.IsTrue(appsInfoResp.rc == "0");
            Assert.IsTrue(appsInfoResp.LABEL == TestUtility.appName);
        }

    }
}
