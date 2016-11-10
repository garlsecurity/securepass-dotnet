using System;
using System.Collections.Generic;

namespace SecurePass.DotNet.Class.PlainObject
{
    class Radius
    {
    }

    public class CommonRadiusAddAndModifyReq : JSONBaseDataRequest
{
        public String RADIUS { get; set; }
        public String NAME { get; set; }
        public String SECRET { get; set; }
        public String GROUP { get; set; }
        public String RFID { get; set; }
    }

    public class RadiusAddReq : CommonRadiusAddAndModifyReq
    {
        public String REALM { get; set; }
    }

    //Radius Add
    public class RadiusAddResp : JSONBaseDataResponse
    {
        public String Radius {get; set; }
    }


    // RadiusList
    public class RadiusListReq : JSONBaseDataRequest
    {
        public String REALM { get; set; }
    }

    public class RadiusListResp : JSONBaseDataResponse
    {
        public List<String> radius { get; set; }
    }

    // Radius info 
    public class RadiusInfoReq : JSONBaseDataRequest
    {
        public String RADIUS { get; set; }
    }

    public class RadiusInfoResp : JSONBaseDataResponse
    {
        public String name { get; set; }
        public String secret { get; set; }
        public String shared { get; set; }
        public String group { get; set; }
        public String realm { get; set; }
        public String rfid { get; set; }

    }

    public class RadiusDeleteReq : RadiusInfoReq
    {
    }

    // Radius modify
    public class RadiusModifyReq : CommonRadiusAddAndModifyReq
    {
        
    }
}
