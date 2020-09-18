using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace S1Custom.Io.HttpWeb
{

    class ItemHttp
    {

        public String syncMTRL(String CODE, String NAME, String PRICER, string[,] PRICERPRC, int totalPriceR, String CATEG_NAME, String CATEG_ID) // String PRICER01, String PRICER02, String PRICER03, String PRICER04, String PRICER05, String PRICER06, String PRICER07, String PRICER08, String PRICER09)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
      
            String strPost = "" ;
                
            if(CATEG_ID.Equals("-1"))
                strPost = "CODE=" + CODE + "&NAME=" + NAME + "&PRICER=" + PRICER ; // +"&PRICER01=" + PRICER01 + "&PRICER02=" + PRICER02 + "&PRICER03=" + PRICER03 + "&PRICER04=" + PRICER04 + "&PRICER05=" + PRICER05 + "&PRICER06=" + PRICER06 + "&PRICER07=" + PRICER07 + "&PRICER08=" + PRICER08 + "&PRICER09=" + PRICER09;
            else
                strPost = "CODE=" + CODE + "&NAME=" + NAME + "&PRICER=" + PRICER + "&CATEG_NAME=" + CATEG_NAME + "&CATEG_ID=" + CATEG_ID; 

            String priceStr = ""; ;
            String value = "" ;

            for (int i = 0; i < totalPriceR; i++)
            {
                priceStr = PRICERPRC[i, 1];
                priceStr = priceStr.Replace(",", ".");

                strPost += "&PRICERPRC[" + PRICERPRC[i, 0] + "]=" + priceStr;
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/Sync");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                newStream = objRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                // myWriter = new StreamWriter(objRequest.GetRequestStream());
                // myWriter.Write(byteArray);
                // myWriter.Write(byteArray, 0, byteArray.Length);

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



               // JArray array = (JArray)ojObject["chats"];
              //  int id = Convert.ToInt32(array[0].toString());


            }
            catch (Exception ex)
            {
                //return e.Message;
            }

            return value;
        }


        public String syncMTRGROUP(String MTRGROUP, String NAME) 
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "MTRGROUP=" + MTRGROUP + "&NAME=" + NAME  ; 
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/SyncCategory");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                newStream = objRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                // myWriter = new StreamWriter(objRequest.GetRequestStream());
                // myWriter.Write(byteArray);
                // myWriter.Write(byteArray, 0, byteArray.Length);

                newStream.Close();

                HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();



                using (StreamReader sr =
                   new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();

                 //   JObject joResponse = JObject.Parse(result);
                 //   value = (String)joResponse["actions"].ToString();
                }



                // JArray array = (JArray)ojObject["chats"];
                //  int id = Convert.ToInt32(array[0].toString());


            }
            catch (Exception ex)
            {
                //return e.Message;
            }

            return value;
        }





        public String getPId(String CODE)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/getPId");
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

                JObject joResponse = JObject.Parse(result);
                value = (String)joResponse["actions"].ToString();
            }

            return value;
        }







        public String delete(String CODE)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;
            String value = "";
 

            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/delete");
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

                JObject joResponse = JObject.Parse(result);
                value = (String)joResponse["actions"].ToString();
            }


            return value;

        }


        public String getProducts(String CODE)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;



            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/delete");
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



        public String active(String CODE)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/activate");
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

                JObject joResponse = JObject.Parse(result);
                value = (String)joResponse["actions"].ToString();

            }

            return value;

        }


        public String connectToMTRL(String item_id, String s1Code)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "ITEM_ID=" + item_id + "&CODE=" + s1Code;
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/connectToProduct");
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

                JObject joResponse = JObject.Parse(result);
                value = (String)joResponse["actions"].ToString();
            }

            return value;
        }

        public JArray getMTRLS()
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "";
            JArray joResponse = null;

            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/getProducts");
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

                joResponse = JArray.Parse(result);
            }

            return joResponse;
        }

        public String SyncImage(String CODE, string Url)
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";

            String strPost = "";

            strPost = "CODE=" + CODE + "&Url=" + settings.images_domain + Url; 
          
            String priceStr = ""; ;
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/product/SyncImage");
            objRequest.Method = "POST";
            objRequest.ContentLength = byteArray.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            try
            {
                newStream = objRequest.GetRequestStream(); //open connection
                newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                newStream.Close();

                // myWriter = new StreamWriter(objRequest.GetRequestStream());
                // myWriter.Write(byteArray);
                // myWriter.Write(byteArray, 0, byteArray.Length);

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
                //return e.Message;
            }

            return value;
        }



        public void UpLoadImage(String image, string target)
        {
            Settings settings = Settings.getInstance();

            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(settings.imagesFtpDomain + target);
            req.UseBinary = true;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(settings.imagesFtpUser, settings.imagesFtpPassword );
           // StreamReader rdr = new StreamReader(image);
           // byte[] fileData = Encoding.UTF8.GetBytes(rdr.ReadToEnd());
            byte[] fileData = File.ReadAllBytes(image);// ReadAllBytes(image);

           // rdr.Close();
            req.ContentLength = fileData.Length;
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(fileData, 0, fileData.Length);
            reqStream.Close();
        }


    }
}
