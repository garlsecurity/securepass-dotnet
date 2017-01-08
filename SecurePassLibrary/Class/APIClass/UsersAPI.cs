using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SecurePass.DotNet.Class.PlainObject;

namespace SecurePass.DotNet.Class.APIClass
{
    
    public class UsersAPI
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

        public UserInfoResp GetUserInfo(UserNameReq userNameReq)
        {
            UserInfoResp userInfoResp = SecurePassRestAPI.client.PostRequestWithParameter<UserInfoResp>(userInfoAPIPathAPIURL , userNameReq);

            return userInfoResp;
        }

        public UserListResp GetUserList()
        {
            UserListResp userListResp = SecurePassRestAPI.client.PostRequest<UserListResp>( userListAPIPathAPIURL);

            return userListResp;
        }

        public UserNameResp addUser(UserDataReq userDataReq)
        {
            UserNameResp userNameResp = SecurePassRestAPI.client.
                PostRequestWithParameter<UserNameResp>( userAddPathAPIURL, userDataReq);

            return userNameResp;

        }

        public IJSONBaseDataResponse deleteUSer(UserNameReq userNameReq)
        {
            JSONBaseDataResponse  
                response= (JSONBaseDataResponse)SecurePassRestAPI.client.PostRequestWithParameter<UserNameResp>( usersDeleteAPIURL, userNameReq);
            return response;
        }

        public JSONBaseDataResponse enableUSer(UserNameReq userNameReq)
        {
            JSONBaseDataResponse response = SecurePassRestAPI.client.PostRequestWithParameter<UserNameResp>( usersEnableAPIURL, userNameReq);
            return response;
        }

        public JSONBaseDataResponse disableUSer(UserNameReq userNameReq)
        {
            JSONBaseDataResponse response = SecurePassRestAPI.client.PostRequestWithParameter<UserNameResp>( usersDisableAPIURL, userNameReq);
            return response;
        }

        public JSONBaseDataResponse UserPasswordDisable(UserNameReq userNameReq)
        {
            JSONBaseDataResponse response = SecurePassRestAPI.client.PostRequestWithParameter<JSONBaseDataResponse>( usersDisablePasswordAPIURL, userNameReq);
            return response;
        }

        public JSONBaseDataResponse UserPasswordChange(UserPasswordChangeReq userPasswordChangeReq)
        {
            JSONBaseDataResponse response = SecurePassRestAPI.client.PostRequestWithParameter<JSONBaseDataResponse>( usersPasswordChangeAPIURL, userPasswordChangeReq);
            return response;
        }

        public XattrListResp UserXattrList(UserNameReq userNameReq)
        {
            //            XattrListResp response = client.PostRequestWithParameter<XattrListResp>(APIVersionPath + usersXattrsListAPIURL, UserNameReq);
            String response = SecurePassRestAPI.client.PostRequestWithParameter( usersXattrsListAPIURL, userNameReq);

            var userXattrList = XAttrs.GetXattrsValue(response);

            return userXattrList;
        }



        // Attribute Name will be tranformed in every case in lower case
        public JSONBaseDataResponse UserXattrSet(UserNameXattrSetReq userNameXattrSetReq)
        {
            JSONBaseDataResponse response = SecurePassRestAPI.client.PostRequestWithParameter<JSONBaseDataResponse>( usersXattrsSetAPIURL, userNameXattrSetReq);
            return response;
        }


    }
}
