using System;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    public class SecurePassRestAPI
    {
        private const String defaultAPIVersionPath = "api/v1/";
        private static SecurePassRestClient internalClient = null;

        public static SecurePassRestClient client
        {
            get
            {
                if (internalClient == null) throw new NullReferenceException("SecurePassRestAPI MUST be initialized before calling RestApi");
                return internalClient;
            }
        }

        private string SecurePassURL = " https://beta.secure-pass.net";
        public  static string APIVersionPath { get; set; }

        public SecurePassRestAPI()
        {
        }

        public SecurePassRestAPI(string SecurePassAppIdHeader,
            string SecurePassAppSecretHeader,
            string Username,
            string Secret)
        {
            internalClient = new SecurePassRestClient(SecurePassAppIdHeader,
                SecurePassAppSecretHeader,
                Username,
                Secret, SecurePassURL);

            APIVersionPath = SecurePassRestAPI.defaultAPIVersionPath;

        }


        // This constructor add two values to standard parameter 
        // 1) apiVersionPath standard parameter API version (if null it revert to default  i.e "/api/v1" )
        // 2) Securepass URL (if null it take defaul value i.e. " https://beta.secure-pass.net") 
        public SecurePassRestAPI(string SecurePassAppIdHeader,
            string SecurePassAppSecretHeader,
            string Username,
            string Secret,
            string apiVersionPath,
            string securePassURL)
        {
            APIVersionPath = (apiVersionPath != null) ? apiVersionPath : APIVersionPath;
            SecurePassURL = (securePassURL != null) ? securePassURL : SecurePassURL;

            internalClient = new SecurePassRestClient(SecurePassAppIdHeader,
            SecurePassAppSecretHeader,
            Username,
            Secret, SecurePassURL);
            APIVersionPath = apiVersionPath;
        }


        public T getAPIValue<T>(String APIurl) where T : IJSONBaseDataResponse, new()
        {
            var result = SecurePassRestAPI.internalClient.PostRequest<T>(APIurl);

            return result;
        }

        public T getAPIValue<T>(String APIurl, JSONBaseDataRequest jsonBaseDataRequest) where T : IJSONBaseDataResponse, new()
        {
            var result = SecurePassRestAPI.internalClient.PostRequestWithParameter<T>(APIurl, jsonBaseDataRequest);

            return result;
        }


    }
}