namespace SecurePass.DotNet.Class.PlainObject
{

    public interface IJSONBaseDataResponse
    {
         string rc { get; set; }
         string errorMsg { get; set; }
    }

    public class JSONBaseDataResponse : IJSONBaseDataResponse
    {
        public  string rc { get; set; }
        public string errorMsg { get; set; }
    }

    public class JSONBaseDataRequest
    {
    }


}
