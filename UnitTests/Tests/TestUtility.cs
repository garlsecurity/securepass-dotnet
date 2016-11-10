using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Class.APIClass;
using ClassLibrary1.Class.PlainObject;

namespace UnitTests.Tests
{
    class TestUtility
    {
        public static String realmTestName = "wiran.net";

        // Radius
        public static string RADIUS_IP_TEST1 = "172.172.172.1";
        public static string RADIUS_IP_TEST2 = "179.179.179.1";
        public static String radiusFQDN1 = "FQDN NAME ONE";
        public static String radiusFQDN2 = "FQDN NAME TWO";
        public static String radiusFQDNModified = "fqdn name modified";

        // Apps
        public static String appName = "TestAppLAbel1";

        public static UserData CreateTestUserObject()
        {
            UserData userData = new UserData();
            userData.USERNAME = $"testuser@{realmTestName}";
            userData.NAME = "test";
            userData.EMAIL = "test@test.com";
            userData.SURNAME = "TestSurname";
            userData.MOBILE = "+193356666666";
            return userData;
        }

        public static UserName GetTestUserName()
        {
            UserName userName = new UserName();
            userName.USERNAME = TestUtility.CreateTestUserObject().USERNAME;
            return userName;
        }


        public static RadiusAddResp CreateTestRadius1(RadiusAPI _radiusApi)
        {
            RadiusAddReq addReq = new RadiusAddReq();
            addReq.RADIUS = TestUtility.RADIUS_IP_TEST1;
            addReq.NAME = radiusFQDN1;
            addReq.RFID = "";
            addReq.GROUP = "";
            addReq.SECRET = "";
            addReq.REALM = TestUtility.realmTestName;

            var radiusAddResp = _radiusApi.radiusAdd(addReq);
            return radiusAddResp;
        }

        public static AppsAddReq AppsAddReq()
        {
            AppsAddReq request = new AppsAddReq();
            request.LABEL = appName;
            request.WRITE = "true";
            request.ALLOWEDNETWORKIPV4 = "";
            request.ALLOWEDNETWORKIPV6 = "";
            request.GROUP = null;
            request.REALM = null;
            return request;
        }


        public static RadiusAddResp CreateTestRadius2(RadiusAPI _radiusApi)
        {
            RadiusAddReq addReq = new RadiusAddReq();
            addReq.RADIUS = TestUtility.RADIUS_IP_TEST2;
            addReq.NAME = radiusFQDN2;
            addReq.RFID = "";
            addReq.GROUP = "";
            addReq.SECRET = "";
            addReq.REALM = TestUtility.realmTestName;

            var radiusAddResp = _radiusApi.radiusAdd(addReq);
            return radiusAddResp;
        }


        public static JSONBaseDataResponse DeleteTestRadius(RadiusAPI _radiusApi , String RadiusName)
        {
            RadiusDeleteReq radiusDeleteReq = new RadiusDeleteReq();
            radiusDeleteReq.RADIUS = RadiusName;
            var radiusInfoResp = _radiusApi.radiusDelete(radiusDeleteReq);
            return radiusInfoResp;
        }


        public static RadiusModifyReq getTestRadiusModify()
        {
            RadiusModifyReq radiusModify = new RadiusModifyReq();
            radiusModify.RADIUS = TestUtility.RADIUS_IP_TEST1;
            radiusModify.NAME = radiusFQDNModified;
            radiusModify.RFID = "";
            radiusModify.GROUP = "";
            radiusModify.SECRET = "";

            return radiusModify;
        }



        public static bool checkIFResponseIsOK(string rc)
        {
            return Int32.Parse(rc) == 0;
        }
    }
}
