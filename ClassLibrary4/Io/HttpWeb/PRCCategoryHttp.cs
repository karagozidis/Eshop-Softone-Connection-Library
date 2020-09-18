using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Net;

namespace S1Custom.Io.HttpWeb
{
    class PRCCategoryHttp
    {

        public String getId(String CODE)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;

            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer_group/getId");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                newStream = objRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
            }
            catch (Exception ex)
            {
                //return e.Message;
            }
            finally
            {
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




        public String delete(String CODE)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;



            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer_group/delete");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";


            try
            {
                newStream = objRequest.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();

            }
            catch (Exception ex)
            {
                //return e.Message;
            }
            finally
            {
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
