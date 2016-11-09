using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Class.PlainObject;

namespace ClassLibrary1.Class.APIClass
{
    public class AppsAPIClass
    {
        public static String appsAddApiURL = "apps/add";
 



        public AppsAddDataResponse addApps(AppsAddDataRequest appsAddDataRequest)
        {
            AppsAddDataResponse userInfo = SecurePassClient.client.PostRequestWithParameter<AppsAddDataResponse>(appsAddApiURL , appsAddDataRequest);

            return userInfo;
        }

    }


}
