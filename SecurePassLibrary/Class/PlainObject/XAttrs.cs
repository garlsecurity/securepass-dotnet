using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SecurePass.DotNet.Class.PlainObject
{
    public class XAttrs
    {
        public static XattrListResp GetXattrsValue(String response)
        {
            Dictionary<string, string> data = GetDictionaryFromJson(response);

            XattrListResp responseXattrListResp = new XattrListResp();
            foreach (string item in data.Keys)
            {
                var value = data[item];
                if (item.Equals("rc"))
                {
                    responseXattrListResp.rc = value;
                    continue;
                }
                if (item.Equals("errorMsg"))
                {
                    responseXattrListResp.errorMsg = value;
                    continue;
                }

                // Xattr values
                responseXattrListResp.values.Add(item, value);
            }
            return responseXattrListResp;
        }

        public static Dictionary<string, string > GetDictionaryFromJson (String json)
        {
            Console.Out.WriteLine("json = {0}", json);

            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return values;
        }

    }

    public class XattrListResp : JSONBaseDataResponse
    {
        public Dictionary<String , String > values  { get; set; }

        public XattrListResp()
        {
            values = new Dictionary<string, string>();
        }
    }


}