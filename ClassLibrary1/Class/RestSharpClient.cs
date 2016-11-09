using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary1.Class;
using ClassLibrary1.Class.PlainObject;
using RestSharp;

namespace ClassLibrary1
{
    public class RestSharpClient
    {
        // Header for Request
        private String XSecurePassAppIDHeader = "X-SecurePass-App-ID";
        private String XSecurePassAppSecretHeader = "X-SecurePass-App-Secret";
        // Header value (prepend a v to header variable name)
        private String vXSecurePassAppIdHeader;
        private String vXSecurePassAppSecretHeader;

        // Request parameter
        private String USERNAMEParameter = "USERNAME";
        private String SECRETParameter = "SECRET";
        // Request parameter value (prepend a v to header variable name)
        private String vUSERNAMEParameter;
        private String vSECRETParameter;

        // Secure pass URL
        private String SecurePassURL;

        private static bool debug = true;


        public T PostRequest<T>(string APIurl) where T : JSONBaseDataResponse , new()
        {
            return PostRequestWithParameter<T>(APIurl, null);
        }

        public T PostRequestWithParameter<T>(string APIurl ,
            JSONBaseDataRequest postData)
            where T : IJSONBaseDataResponse, new()
        {
            var fullApiurl = getFullAPIURL(APIurl);

            RestRequest request;
            var client = prepareRequest(fullApiurl, postData, out request);

            IRestResponse response1 = client.Execute(request);
            IRestResponse<T> response = client.Execute<T>(request);

            var postRequestWithJsonRequestBody = response.Data;
            if (debug) Console.WriteLine("Response" + request.JsonSerializer.Serialize(postRequestWithJsonRequestBody));
            return postRequestWithJsonRequestBody;
        }

        // Request for response with no predefined type of data contained in
        public String PostRequestWithParameter(string APIurl, JSONBaseDataRequest postData)
        {
            var fullApiurl = getFullAPIURL(APIurl);

            RestRequest request;
            var client = prepareRequest(fullApiurl, postData, out request);
            IRestResponse response1 = client.Execute(request);
            return response1.Content;

        }

        private static string getFullAPIURL(string APIurl) 
        {
            return SecurePassClient.APIVersionPath + APIurl;
        }


        private RestClient prepareRequest(string APIurl, 
            JSONBaseDataRequest postData,
            out RestRequest request)
        {
            if (debug) Console.Out.WriteLine("Requested API URL " + APIurl);
            var client = new RestClient(SecurePassURL);

            request = AddMandatoryHeaderAndParameter(APIurl);

            if (postData != null) AddPostParameter(postData, request);
            return client;
        }

        private static void AddPostParameter(JSONBaseDataRequest postData, RestRequest request)
        {
            if (debug) Console.WriteLine("Request " + request.JsonSerializer.Serialize(postData));

            var list = CreateKeyValuePairsListsFromObject(postData);
            for (int i = 0; i < list.Count; i++)
            {
                var keyValuePair = list[i];
                request.AddParameter(keyValuePair.Key, keyValuePair.Value, ParameterType.GetOrPost);
            }
        }


        private RestRequest AddMandatoryHeaderAndParameter(string APIurl) 
        {
            var request = new RestRequest(APIurl, Method.POST);
            //  HTTP Headers
            request.AddHeader(XSecurePassAppIDHeader, vXSecurePassAppIdHeader);
            request.AddHeader("X-SecurePass-App-Secret", vXSecurePassAppSecretHeader);

            request.AddParameter("USERNAME", vUSERNAMEParameter);
            request.AddParameter("SECRET", vSECRETParameter);
            if (debug) DumpMandatoryHeader()
            ;
            return request;
        }

        private void DumpMandatoryHeader()
        {
            Console.Out.WriteLine("Secure pass Mandatory Header");
            Console.Out.WriteLine("XSecurePassAppIDHeader " + vXSecurePassAppIdHeader);
            Console.Out.WriteLine("X -SecurePass-App-Secret " + vXSecurePassAppSecretHeader);
            Console.Out.WriteLine("USERNAME " + vUSERNAMEParameter);
            Console.Out.WriteLine("SECRET " + vSECRETParameter);

        }


        public static List<KeyValuePair<string, string>> CreateKeyValuePairsListsFromObject(Object plainObject)
        {
            var list = new List<KeyValuePair<string, string>>();
            foreach (var prop in plainObject.GetType().GetProperties())
            {
                String name = prop.Name;
                String value = (String) prop.GetValue(plainObject, null);
                if (debug) Console.WriteLine("{0}={1}", name, value);
                list.Add(new KeyValuePair<string, string>(name, value));
            }
            return list;
        }

        public RestSharpClient(string vXSecurePassAppIdHeader,
            string vXSecurePassAppSecretHeader,
            string vUsernameParameter,
            string vSecretParameter,
            string securePassUrl)
        {
            this.vXSecurePassAppIdHeader = vXSecurePassAppIdHeader;
            this.vXSecurePassAppSecretHeader = vXSecurePassAppSecretHeader;
            this.vUSERNAMEParameter = vUsernameParameter;
            this.vSECRETParameter = vSecretParameter;
            this.SecurePassURL = securePassUrl;
        }


    }
}