using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Class.PlainObject;
using Newtonsoft.Json;

namespace ClassLibrary1.Class
{
    
    public class APIClass
    {
        RestSharpClient client = null;

        private string SecurePassURL = " https://beta.secure-pass.net";

        private const String defaultAPIVersionPath = "api/v1/";

        private String APIVersionPath = null;

        public static String userInfoAPIPathAPIURL = "users/info";
        public static String userListAPIPathAPIURL = "users/list";
        public static String userEnablePathAPIURL = "users/enable";
        public static String userAddPathAPIURL = "users/add";
        public static String usersDeleteAPIURL = "users/delete";
        public static String usersEnableAPIURL = "users/enable";
        public String usersDisableAPIURL = "users/disable";
        public String usersDisablePasswordAPIURL = "users/password/disable";
        public String usersPasswordChangeAPIURL = "users/password/change";
        public String usersXattrsListAPIURL = " users/xattrs/list";
        public String usersXattrsSetAPIURL = "users/xattrs/set";



        public APIClass(string SecurePassAppIdHeader,
            string SecurePassAppSecretHeader,
            string Username,
            string Secret)
        {
            client = new RestSharpClient(SecurePassAppIdHeader,
                SecurePassAppSecretHeader,
                Username,
                Secret,
                SecurePassURL);

            APIVersionPath = defaultAPIVersionPath;

        }


        // This constructor add two values to standard parameter 
        // 1) apiVersionPath standard parameter API version (if null it revert to default  i.e "/api/v1" )
        // 2) Securepass URL (if null it take defaul value i.e. " https://beta.secure-pass.net") 
        public APIClass(string SecurePassAppIdHeader,
            string SecurePassAppSecretHeader,
            string Username,
            string Secret,
            string apiVersionPath,
            string securePassURL)
        {
            this.APIVersionPath = (apiVersionPath != null) ? apiVersionPath : this.APIVersionPath;
            this.SecurePassURL =  (securePassURL != null) ? securePassURL : this.SecurePassURL;

            client = new RestSharpClient(SecurePassAppIdHeader,
            SecurePassAppSecretHeader,
            Username,
            Secret,
            SecurePassURL);
            APIVersionPath = apiVersionPath;
        }


        public T getAPIValue<T>(String APIurl) where T : JSONBaseDataResponse, new()
        {
            var result = client.PostRequest<T>(APIVersionPath + APIurl);

            return result;
        }

        public T getAPIValue<T>(String APIurl , JSONBaseDataRequest jsonBaseDataRequest) where T : JSONBaseDataResponse, new()
        {
            var result = client.PostRequestWithParameter<T>(APIVersionPath + APIurl , jsonBaseDataRequest);

            return result;
        }


        public UserInfo GetUserInfo(UserName userName)
        {
            UserInfo userInfo = client.PostRequestWithParameter<UserInfo>(APIVersionPath + userInfoAPIPathAPIURL , userName);

            return userInfo;
        }

        public UserList GetUserList()
        {
            UserList userList = client.PostRequest<UserList>(APIVersionPath + userListAPIPathAPIURL);

            return userList;
        }

        public UserNameResponse addUser(UserData userData)
        {
            UserNameResponse userNameResponse = client.
                PostRequestWithParameter<UserNameResponse>(APIVersionPath + userAddPathAPIURL, userData);

            return userNameResponse;

        }

        public JSONBaseDataResponse deleteUSer(UserName userName)
        {
            JSONBaseDataResponse  response= client.PostRequestWithParameter<UserNameResponse>(APIVersionPath + usersDeleteAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse enableUSer(UserName userName)
        {
            JSONBaseDataResponse response = client.PostRequestWithParameter<UserNameResponse>(APIVersionPath + usersEnableAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse disableUSer(UserName userName)
        {
            JSONBaseDataResponse response = client.PostRequestWithParameter<UserNameResponse>(APIVersionPath + usersDisableAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse UserPasswordDisable(UserName userName)
        {
            JSONBaseDataResponse response = client.PostRequestWithParameter<JSONBaseDataResponse>(APIVersionPath + usersDisablePasswordAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse UserPasswordChange(UserPasswordChange userPasswordChange)
        {
            JSONBaseDataResponse response = client.PostRequestWithParameter<JSONBaseDataResponse>(APIVersionPath + usersPasswordChangeAPIURL, userPasswordChange);
            return response;
        }

        public UserXattrList UserXattrList(UserName userName)
        {
            //            UserXattrList response = client.PostRequestWithParameter<UserXattrList>(APIVersionPath + usersXattrsListAPIURL, userName);
            String response = client.PostRequestWithParameter(APIVersionPath + usersXattrsListAPIURL, userName);


            Dictionary<string, string> data = getDictionaryFromJson(response);

            var userXattrList = GetXattrsValue(data);

            return userXattrList;
        }

        private static UserXattrList GetXattrsValue(Dictionary<string, string> data)
        {
            UserXattrList responseUserXattrList = new UserXattrList();
            foreach (string item in data.Keys)
            {
                var value = data[item];
                if (item.Equals("rc"))
                {
                    responseUserXattrList.rc = value;
                    continue;
                }
                if (item.Equals("errorMsg"))
                {
                    responseUserXattrList.errorMsg = value;
                    continue;
                }

                if (!item.Equals("zz"))
                {
                    responseUserXattrList.values.Add(item, value);
                }
            }
            return responseUserXattrList;
        }

        // Attribute Name will be tranformed in every case in lower case
        public JSONBaseDataResponse UserXattrSet(UserNameXattrSet userNameXattrSet)
        {
            JSONBaseDataResponse response = client.PostRequestWithParameter<JSONBaseDataResponse>(APIVersionPath + usersXattrsSetAPIURL, userNameXattrSet);
            return response;
        }

        private Dictionary<string, string > getDictionaryFromJson (String json)
        {
            Console.Out.WriteLine("json = {0}", json);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return values;
        }

    }
}
