using System;
using System.Collections.Generic;

namespace SecurePass.DotNet.Class.PlainObject
{
    class User
    {
    }


    public class UserNameReq : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
    }

    public class UserDataReq : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public String EMAIL { get; set; }
        public String MOBILE { get; set; }
        public String NIN { get; set; } // Optional
    }


    public class UserNameXattrSetReq : JSONBaseDataRequest
    {
       public string USERNAME { get; set; }
        public string ATTRIBUTE { get; set; }
        public string VALUE { get; set; }
    }
    public class UserPasswordChangeReq : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
        public String PASSWORD { get; set; }
    }


    public class UserListResp : JSONBaseDataResponse
    {
        private List<String> username;

        public List<string> Username
        {
            get { return username; }
            set { username = value; }
        }
    }


    public class UserNameResp : JSONBaseDataResponse
    {
        public String userName { get; set; }
    }

    public class UserInfoResp : JSONBaseDataResponse
    {
        public string Nin { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string ErrorMsg { get; set; }
        public bool Enabled { get; set; }
        public string Token { get; set; }
        public string Manager { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
