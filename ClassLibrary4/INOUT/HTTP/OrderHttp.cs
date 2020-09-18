using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace S1Custom.Io.HttpWeb
{
    class OrderHttp
    {

        public JArray getOrdersByDate(String from, String to) 
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "from=" + from + "&to=" + to;
            JArray joResponse = null;
            //String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/order/getOrders");
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
                   
                     joResponse = JArray.Parse(result);
                   // MessageBox.Show( joResponse.Count.ToString() );              
                   // value = (String)joResponse[0]["order_id"].ToString();
                }

            }
            catch (Exception ex)
            {

            }
            return joResponse;

        }

        public JArray getOrder(String OrderId)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "oId=" + OrderId;
            JArray joResponse = null;
            //String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/order/getOrder");
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
                   
                    joResponse = JArray.Parse(result);
                  //  MessageBox.Show( joResponse.ToString() );
                  //  MessageBox.Show( joResponse.ToString() );              
                  //  value = (String)joResponse[0]["order_id"].ToString();
                }
            }
            catch (Exception ex)
            {

            }
            return joResponse;

        }


    }
}
