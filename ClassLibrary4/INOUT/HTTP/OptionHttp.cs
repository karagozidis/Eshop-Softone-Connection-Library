using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Collections;
using S1Custom;
using Newtonsoft.Json.Linq;

namespace ClassLibrary4
{
    class OptionHttp
    {
        public String syncOptions(String CODE, String NAME, List<string[]> OPTIONS)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "" ;

            strPost = "CODE=" + CODE + "&NAME=" + NAME ;

            foreach (string[] value in OPTIONS)
	        {
                strPost += "&OPTIONS[" + value[0] + "]=" + value[1] ;
            }
         
            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/SyncOption");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                newStream = objRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                newStream.Close();

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

                using (StreamReader sr =
                   new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();

                    JObject joResponse = JObject.Parse(result);
                    result = (String)joResponse["actions"].ToString();
                }

            }
            catch (Exception ex)
            {
            }

            return result;
        }



    }
}
