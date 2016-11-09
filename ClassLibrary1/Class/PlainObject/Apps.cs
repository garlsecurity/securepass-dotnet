using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1.Class.PlainObject
{
    class Apps
    {
    }

    public class AppsAddDataRequest : JSONBaseDataRequest
    {
        public string LABEL { get; set; }

        public string ALLOWEDNETWORKIPV4 { get; set; }

        public string ALLOWEDNETWORKIPV6 { get; set; }

        public string WRITE { get; set; }

        public string GROUP { get; set; }

        public string REALM { get; set; }
    }

    public class AppsAddDataResponse : JSONBaseDataResponse
    {
        public string app_id { get; set; }
        public string app_secret { get; set; }
}
}
