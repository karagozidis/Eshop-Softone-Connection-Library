using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using S1Custom;

namespace ClassLibrary4
{
    public class CDIMHttp
    {

        public String sync(String CODE, String NAME)
        {
            Settings settings = Settings.getInstance();

            //String id = "2";
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE + "&NAME=" + NAME;

            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer_group/Sync");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";


            try
            {
                newStream = objRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                //myWriter = new StreamWriter(objRequest.GetRequestStream());
                //myWriter.Write(byteArray);
                // myWriter.Write(byteArray, 0, byteArray.Length);


            }
            catch (Exception ex)
            {
                //return e.Message;
            }
            finally
            {
                // myWriter.Close();
                //  newStream.Close();
                newStream.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr =
               new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }


            return result;

        }
    }
}
