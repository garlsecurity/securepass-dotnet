using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class RadiusAPI
    {
        public String RadiusAddAPIURL = "radius/add";
        public String RadiusListAPIURL = "radius/list";
        public String RadiusInfoAPIURL = "radius/info";
        public String RadiusDeleteAPIURL = "radius/delete";
        public String RadiusModifyAPIURL = "radius/modify";


        public RadiusAddResp radiusAdd(RadiusAddReq radiusAddReq)
        {
            RadiusAddResp radiusAddResp = SecurePassRestAPI.client.
                PostRequestWithParameter<RadiusAddResp>(RadiusAddAPIURL, radiusAddReq);

            return radiusAddResp;
        }

        public RadiusListResp radiusList(RadiusListReq radiusListReq)
        {
            RadiusListResp radiusListResp = SecurePassRestAPI.client.
                PostRequestWithParameter<RadiusListResp>(RadiusListAPIURL, radiusListReq);

            return radiusListResp;
        }

        public RadiusInfoResp radiusInfo(RadiusInfoReq radiusInfoReq)
        {
            RadiusInfoResp radiusInfoResp = SecurePassRestAPI.client.
                PostRequestWithParameter<RadiusInfoResp>(RadiusInfoAPIURL, radiusInfoReq);
            return radiusInfoResp;
        }

        public JSONBaseDataResponse radiusDelete(RadiusDeleteReq radiusDeleteReq)
        {
            JSONBaseDataResponse radiusInfoResp = SecurePassRestAPI.client.
                PostRequestWithParameter<JSONBaseDataResponse>(RadiusDeleteAPIURL, radiusDeleteReq);
            return radiusInfoResp;
        }

        public JSONBaseDataResponse radiusModify(RadiusModifyReq modifyReq)
        {
            JSONBaseDataResponse baseDataResponse = SecurePassRestAPI.client.
                PostRequestWithParameter<JSONBaseDataResponse>(RadiusModifyAPIURL, modifyReq);
            return baseDataResponse;
        }

    }
}