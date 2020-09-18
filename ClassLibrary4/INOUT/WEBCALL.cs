using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using S1Custom;

namespace ClassLibrary4.INOUT
{
    public static class WEBCALL
    {
        public static String CALL(String WEBURL,String POSTPARAMETERS)
        {
            
            Stream newStream = null;
            String result = "";
            String value = "";

            try
            {

            byte[] byteArray = Encoding.UTF8.GetBytes(POSTPARAMETERS);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(WEBURL);
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

           
                newStream = objRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();

                newStream.Close();

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();

                using (StreamReader sr =
                   new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();

                    JObject joResponse = JObject.Parse(result);
                    value = (String)joResponse["actions"].ToString();
                }

            }
            catch (Exception ex)
            {

                VWEBEXCEPTION.SaveToLog("[JSON CALL] " + ex.Message, WEBURL + "\r\n" + POSTPARAMETERS + "\r\n" + result);
            }

            return value;
        }


    }
}
