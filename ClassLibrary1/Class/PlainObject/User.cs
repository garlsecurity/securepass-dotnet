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

    public class JSONBaseDataRequest
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

    public interface IJSONBaseDataResponse
    {

    }

    public class JSONBaseDataResponse : IJSONBaseDataResponse
    {
        public string rc { get; set; }

        public string errorMsg { get; set; }
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
        String nin;
        String name;
        String mobile;
        String errorMsg;
        Boolean enabled;
        String token;
        String manager;
        String surname;
        String password;
        String email;

        public string Nin
        {
            get { return nin; }
            set { nin = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string ErrorMsg
        {
            get { return errorMsg; }
            set { errorMsg = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        public string Manager
        {
            get { return manager; }
            set { manager = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }



    }
}
