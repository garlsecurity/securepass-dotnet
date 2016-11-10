namespace SecurePass.DotNet.Class.PlainObject
{
    class Apps
    {
    }

    public class AppsAddReq : JSONBaseDataRequest
    {
        public string LABEL { get; set; }
        public string ALLOWEDNETWORKIPV4 { get; set; }
        public string ALLOWEDNETWORKIPV6 { get; set; }
        public string WRITE { get; set; }
        public string GROUP { get; set; }
        public string REALM { get; set; }
    }

    public class AppsAddDataResp : JSONBaseDataResponse
    {
        public string app_id { get; set; }
        public string app_secret { get; set; }
    }

    public class AppsDeleteReq : JSONBaseDataRequest
    {
        public string APP_ID { get; set; }
    }

    public class AppsInfoReq : AppsDeleteReq
    {
        
    }

    public class AppsInfoResp : JSONBaseDataResponse
    {
        public string app_id { get; set; }
        public string LABEL { get; set; }
        public string ALLOWEDNETWORKIPV4 { get; set; }
        public string ALLOWEDNETWORKIPV6 { get; set; }
        public string WRITE { get; set; }
        public string GROUP { get; set; }
        public string REALM { get; set; }
    }

}
