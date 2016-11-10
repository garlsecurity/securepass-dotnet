using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace ClassLibrary1.Class.PlainObject
{
    class User
    {
    }


    public class UserName : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
    }

    public class UserData : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public String EMAIL { get; set; }
        public String MOBILE { get; set; }
        public String NIN { get; set; } // Optional
    }


    public class UserNameXattrSet : JSONBaseDataRequest
    {
       public string USERNAME { get; set; }
        public string ATTRIBUTE { get; set; }
        public string VALUE { get; set; }
    }
    public class UserPasswordChange : JSONBaseDataRequest
    {
        public String USERNAME { get; set; }
        public String PASSWORD { get; set; }
    }


    public class UserList : JSONBaseDataResponse
    {
        private List<String> username;

        public List<string> Username
        {
            get { return username; }
            set { username = value; }
        }
    }

    public class UserXattrList : JSONBaseDataResponse
    {
        public Dictionary<String, String> values = new Dictionary<string, string>();
    }


    public class UserNameResponse : JSONBaseDataResponse
    {
        public String userName { get; set; }
    }

    public class UserInfo : JSONBaseDataResponse
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
