using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class AppsAPI
    {
        public static String appsAddApiURL = "apps/add";
        public static String appsDeleteApiURL = "apps/delete";
        public static String appsInfoApiURL = "apps/info";


        public AppsAddDataResp addApps(AppsAddReq appsAddReq)
        {
            AppsAddDataResp userInfo = SecurePassRestAPI.client.PostRequestWithParameter<AppsAddDataResp>(appsAddApiURL , appsAddReq);

            return userInfo;
        }

        public JSONBaseDataResponse deleteApps(AppsDeleteReq appsDeleteReq)
        {
            JSONBaseDataResponse baseDataResponse = SecurePassRestAPI.client.
                PostRequestWithParameter<JSONBaseDataResponse>(appsDeleteApiURL, appsDeleteReq);

            return baseDataResponse;
        }

        public AppsInfoResp info(AppsInfoReq appsInfoReq)
        {
            AppsInfoResp appsInfoResp = SecurePassRestAPI.client.
                PostRequestWithParameter<AppsInfoResp>(appsInfoApiURL, appsInfoReq);

            return appsInfoResp;
        }

    }


}
