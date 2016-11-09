using System;
using ClassLibrary1.Class.PlainObject;

namespace ClassLibrary1.Class
{
    public class SecurePassClient
    {
        private const String defaultAPIVersionPath = "api/v1/";
        public static RestSharpClient client = null;
        private string SecurePassURL = " https://beta.secure-pass.net";
        public  static string APIVersionPath { get; set; }

        public SecurePassClient()
        {
        }

        public SecurePassClient(string SecurePassAppIdHeader,
            string SecurePassAppSecretHeader,
            string Username,
            string Secret)
        {
            client = new RestSharpClient(SecurePassAppIdHeader,
                SecurePassAppSecretHeader,
                Username,
                Secret, SecurePassURL);

            APIVersionPath = SecurePassClient.defaultAPIVersionPath;

        }


        // This constructor add two values to standard parameter 
        // 1) apiVersionPath standard parameter API version (if null it revert to default  i.e "/api/v1" )
        // 2) Securepass URL (if null it take defaul value i.e. " https://beta.secure-pass.net") 
        public SecurePassClient(string SecurePassAppIdHeader,
            string SecurePassAppSecretHeader,
            string Username,
            string Secret,
            string apiVersionPath,
            string securePassURL)
        {
            APIVersionPath = (apiVersionPath != null) ? apiVersionPath : APIVersionPath;
            SecurePassURL = (securePassURL != null) ? securePassURL : SecurePassURL;

            client = new RestSharpClient(SecurePassAppIdHeader,
            SecurePassAppSecretHeader,
            Username,
            Secret, SecurePassURL);
            APIVersionPath = apiVersionPath;
        }


        public T getAPIValue<T>(String APIurl) where T : JSONBaseDataResponse, new()
        {
            var result = SecurePassClient.client.PostRequest<T>(APIurl);

            return result;
        }

        public T getAPIValue<T>(String APIurl, JSONBaseDataRequest jsonBaseDataRequest) where T : JSONBaseDataResponse, new()
        {
            var result = SecurePassClient.client.PostRequestWithParameter<T>(APIurl, jsonBaseDataRequest);

            return result;
        }


    }
}