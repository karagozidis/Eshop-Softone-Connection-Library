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
    class CustomerHttp
    {


    public JArray getCustomers()
        {
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "";
            JArray joResponse = null;

            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer/getCustomers");
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



    public String setPSD(String PSD,String Code)
    {




        Settings settings = Settings.getInstance();


        Stream newStream = null;
        String result = "";
        String strPost = "PSD=" + PSD + "&CODE=" + Code;


        byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer/setSpd");
        objRequest.Method = "POST";
        objRequest.ContentLength = byteArray.Length;
        objRequest.ContentType = "application/x-www-form-urlencoded";


        try
        {
            newStream = objRequest.GetRequestStream(); //open connection
            newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
            newStream.Close();



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



    public String syncCustomer(String CODE, String NAME,String LASTNAME, String JOBTYPETRD, String ADDRESS, String ZIP, String CITY, String PHONE01, String PASSWORD, String FAX, String EMAIL, String PRCCATEGORY)
            {
                Settings settings = Settings.getInstance();
                String value = "";
              
                Stream newStream = null;
                String result = "";
                String strPost = "CODE=" + CODE + "&NAME=" + NAME + "&LASTNAME=" + LASTNAME + "&JOBTYPETRD=" + JOBTYPETRD + "&ADDRESS=" + ADDRESS + "&ZIP=" + ZIP + "&CITY=" + CITY + "&PHONE01=" + PHONE01 + "&AFM=" + PASSWORD + "&FAX=" + FAX + "&EMAIL=" + EMAIL + "&PRCCATEGORY=" + PRCCATEGORY;



                byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
                HttpWebRequest objRequest = (HttpWebRequest) WebRequest.Create(settings.domain + "index.php?route=softone/customer/Sync");
                objRequest.Method = "POST";
                objRequest.ContentLength = byteArray.Length;
                objRequest.ContentType = "application/x-www-form-urlencoded";
                

                try
                {
                    newStream = objRequest.GetRequestStream(); //open connection
                    newStream.Write(byteArray, 0, byteArray.Length); // Send the data.
                    newStream.Close();
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

                        JObject joResponse = JObject.Parse(result);
                        value = (String)joResponse["actions"].ToString();

                    }
                    
            return value;
            }


    public String getCId(String CODE)
            {
                Settings settings = Settings.getInstance();
                Stream newStream = null;
                String result = "";
                String strPost = "CODE=" + CODE;
                String value;

                byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "/index.php?route=softone/customer/getCId");
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
                    value = (String)joResponse["CId"].ToString();
                }

                return value;
            }



    public String connectToCustomer(String customer_id, String s1Code)
    {
        //String url1 = "http://localhost/rfcom/index.php?route=softone/customer/activateCustomer";
        Settings settings = Settings.getInstance();
        Stream newStream = null;
        String result = "";
        String strPost = "CUSTOMER_ID=" + customer_id + "&CODE=" + s1Code;
        String value = "";


        byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer/connectToCustomer");
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




        public String activeCustomer(String CODE)
            {
                //String url1 = "http://localhost/rfcom/index.php?route=softone/customer/activateCustomer";
                Settings settings = Settings.getInstance();
                Stream newStream = null;
                String result = "";
                String strPost = "CODE=" + CODE;
                String value = "";


                byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
                HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer/activateCustomer");
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



        public String isActiveCustomer(String CODE)
        {
            //String url1 = "http://localhost/rfcom/index.php?route=softone/customer/isActiveCustomer";
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer/isActiveCustomer");
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


        public String deleteCustomer(String CODE)
        {
            //   String url1 = "http://localhost/rfcom/index.php?route=softone/customer/deleteCustomer";
            Settings settings = Settings.getInstance();
            Stream newStream = null;
            String result = "";
            String strPost = "CODE=" + CODE;
            String value = "";


            byte[] byteArray = Encoding.UTF8.GetBytes(strPost);
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(settings.domain + "index.php?route=softone/customer/deleteCustomer");
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



    }

}
