using System;
using System.Text;
using System.Collections.Generic;
using ClassLibrary1.Class;
using ClassLibrary1.Class.APIClass;
using ClassLibrary1.Class.PlainObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Tests
{
    /// <summary>
    /// Summary description for RadiusAPITest
    /// </summary>
    [TestClass]
    public class RadiusAPITest
    {
        public RadiusAPITest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        private static RadiusAPI _radiusApi;
        private static SecurePassRestAPI _securePassRestApi;

        [ClassInitialize()]
        public static void InitializeTestClass(TestContext context)
        {
            _radiusApi = new RadiusAPI();
            _securePassRestApi = new SecurePassRestAPI(SecurePassTestAuth.SecurePassAppID,
                SecurePassTestAuth.SecurePassAppSecret, SecurePassTestAuth.SecurePassUsername,
                SecurePassTestAuth.SecurePassSecret);
        }


        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestUtility.DeleteTestRadius(_radiusApi , TestUtility.radiusFQDN1);
            TestUtility.DeleteTestRadius(_radiusApi, TestUtility.radiusFQDN2);
        }
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            TestUtility.DeleteTestRadius(_radiusApi, TestUtility.RADIUS_IP_TEST1);
            TestUtility.DeleteTestRadius(_radiusApi, TestUtility.RADIUS_IP_TEST2);
        }
        //

        #endregion

        [TestMethod]
        public void TestRadiusAdd()
        {
            var radiusAddResp = TestUtility.CreateTestRadius1(_radiusApi);
            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(radiusAddResp.rc);
            Assert.IsTrue(checkIfResponseIsOk);
        }


        [TestMethod]
        public void testRadiusList()
        {
            var radiusAddResp = TestUtility.CreateTestRadius1(_radiusApi);
            radiusAddResp = TestUtility.CreateTestRadius2(_radiusApi);

            RadiusListReq radiusListReq = new RadiusListReq();
            radiusListReq.REALM = TestUtility.realmTestName;
            var radiusListResp = _radiusApi.radiusList(radiusListReq);
            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(radiusListResp.rc);
            Assert.IsTrue(checkIfResponseIsOk);
            Assert.IsTrue(radiusListResp.radius.Count == 2);
        }

        [TestMethod]
        public void testRadiusInfo()
        {
            var radiusAddResp = TestUtility.CreateTestRadius1(_radiusApi);

            RadiusInfoReq radiusInfoReq = new RadiusInfoReq();
            radiusInfoReq.RADIUS = TestUtility.RADIUS_IP_TEST1;
            var radiusInfoResp = _radiusApi.radiusInfo(radiusInfoReq);
            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(radiusInfoResp.rc);
            Assert.IsTrue(checkIfResponseIsOk);

        }

        [TestMethod]
        public void testRadiusDelete()
        {
            // Prepare Test Radius
            var radiusAddResp = TestUtility.CreateTestRadius1(_radiusApi);

            var radiusInfoResp = TestUtility.DeleteTestRadius(_radiusApi , TestUtility.RADIUS_IP_TEST1);
            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(radiusInfoResp.rc);
            Assert.IsTrue(checkIfResponseIsOk);

        }


        [TestMethod]
        public void testDoubleDeleteSameRadius()
        {

            RadiusDeleteReq radiusDeleteReq = new RadiusDeleteReq();
            radiusDeleteReq.RADIUS = TestUtility.RADIUS_IP_TEST1;
            var radiusInfoResp = _radiusApi.radiusDelete(radiusDeleteReq);

            // Second Delete should always give an error
            radiusInfoResp = _radiusApi.radiusDelete(radiusDeleteReq);

            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(radiusInfoResp.rc);
            Assert.IsFalse(checkIfResponseIsOk);

        }

        [TestMethod]
        public void testRadiusMOdify()
        {
            // Prepare Test Radius
            var radiusAddResp = TestUtility.CreateTestRadius1(_radiusApi);

            RadiusModifyReq modifyReq = TestUtility.getTestRadiusModify();
            var jsonBaseDataResponse = _radiusApi.radiusModify(modifyReq);

            bool checkIfResponseIsOk = TestUtility.checkIFResponseIsOK(jsonBaseDataResponse.rc);
            Assert.IsTrue(checkIfResponseIsOk);

            RadiusInfoReq radiusInfoReq = new RadiusInfoReq();
            radiusInfoReq.RADIUS = TestUtility.RADIUS_IP_TEST1;
            var radiusInfoResp = _radiusApi.radiusInfo(radiusInfoReq);
            Assert.IsTrue(radiusInfoResp.name == TestUtility.radiusFQDNModified);
        }
    }

}

