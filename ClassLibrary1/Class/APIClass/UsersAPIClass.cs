using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Class.PlainObject;
using Newtonsoft.Json;

namespace ClassLibrary1.Class
{
    
    public class UsersAPIClass
    {

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
        private readonly SecurePassClient _securePassClient;




        public UserInfo GetUserInfo(UserName userName)
        {
            UserInfo userInfo = SecurePassClient.client.PostRequestWithParameter<UserInfo>(userInfoAPIPathAPIURL , userName);

            return userInfo;
        }

        public UserList GetUserList()
        {
            UserList userList = SecurePassClient.client.PostRequest<UserList>( userListAPIPathAPIURL);

            return userList;
        }

        public UserNameResponse addUser(UserData userData)
        {
            UserNameResponse userNameResponse = SecurePassClient.client.
                PostRequestWithParameter<UserNameResponse>( userAddPathAPIURL, userData);

            return userNameResponse;

        }

        public JSONBaseDataResponse deleteUSer(UserName userName)
        {
            JSONBaseDataResponse  response= SecurePassClient.client.PostRequestWithParameter<UserNameResponse>( usersDeleteAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse enableUSer(UserName userName)
        {
            JSONBaseDataResponse response = SecurePassClient.client.PostRequestWithParameter<UserNameResponse>( usersEnableAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse disableUSer(UserName userName)
        {
            JSONBaseDataResponse response = SecurePassClient.client.PostRequestWithParameter<UserNameResponse>( usersDisableAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse UserPasswordDisable(UserName userName)
        {
            JSONBaseDataResponse response = SecurePassClient.client.PostRequestWithParameter<JSONBaseDataResponse>( usersDisablePasswordAPIURL, userName);
            return response;
        }

        public JSONBaseDataResponse UserPasswordChange(UserPasswordChange userPasswordChange)
        {
            JSONBaseDataResponse response = SecurePassClient.client.PostRequestWithParameter<JSONBaseDataResponse>( usersPasswordChangeAPIURL, userPasswordChange);
            return response;
        }

        public UserXattrList UserXattrList(UserName userName)
        {
            //            UserXattrList response = client.PostRequestWithParameter<UserXattrList>(APIVersionPath + usersXattrsListAPIURL, userName);
            String response = SecurePassClient.client.PostRequestWithParameter( usersXattrsListAPIURL, userName);


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
            JSONBaseDataResponse response = SecurePassClient.client.PostRequestWithParameter<JSONBaseDataResponse>( usersXattrsSetAPIURL, userNameXattrSet);
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
