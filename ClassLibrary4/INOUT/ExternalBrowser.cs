using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace S1Custom
{
    class ExternalBrowser
    {
        //public String page;

        public ExternalBrowser() { }


        public void adminOpenOld(String page)
        {
            Settings setting = Settings.getInstance();

            try
            {
                // Create an instance of StreamReader to read from a file. 
                // The using statement also closes the StreamReader. 
                StreamWriter sw = new StreamWriter(@"C:\vitatron\adminLogIn_tmp.html");
                using (StreamReader sr = new StreamReader(@"C:\vitatron\adminLogIn.html"))
                {
                    string htmlText = ""; 
                    htmlText = sr.ReadToEnd();

                    htmlText = htmlText.Replace("#d#o#m#a#i#n#", setting.domain + "admin/index.php?route=common/login");
                    htmlText = htmlText.Replace("#u#s#e#r#", setting.user);
                    htmlText = htmlText.Replace("#p#a#s#s#", setting.password);
                    htmlText = htmlText.Replace("#p#a#g#e#", page);

                  
                    sw.Write(htmlText);
          
                }

              sw.Close();

              System.Diagnostics.Process.Start("file:///C:/vitatron/adminLogIn_tmp.html");
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }



        public void adminOpen(String page)
        {
            Settings setting = Settings.getInstance();

            try
            {
                // Create an instance of StreamReader to read from a file. 
                // The using statement also closes the StreamReader. 

                StreamWriter sw = new StreamWriter(System.IO.Path.GetTempPath() + "adminLogIn_tmp.html");
               // using (StreamReader sr = new StreamReader(@"C:\vitatron\adminLogIn.html"))
               // {
                string htmlText =   " <html> " +
                                    " <head></head> " +
                                    " <body onload=document.getElementById('form').submit();> " +
                                    "   <form action='#d#o#m#a#i#n#' method='post' enctype='multipart/form-data' id='form'> " +
                                    "           <input type='text' name='username' value='#u#s#e#r#' style='margin-top: 4px;display: none;' /> " +
                                    "           <input type='password' name='password' value='#p#a#s#s#' style='margin-top: 4px;display: none;' /> " +
                                    "           <a onclick=\"$('#form').submit();\" class='button'></a> " +
                                    "           <input type='hidden' name='redirect' style='display: none;' value='#p#a#g#e#' /> " +
                                    "   </form> " +
                                    " </body> " +
                                    " </html> "; 



                   // htmlText = sr.ReadToEnd();

                    htmlText = htmlText.Replace("#d#o#m#a#i#n#", setting.domain + "/" +  setting.AdminPath + "/index.php?route=common/login");
                    htmlText = htmlText.Replace("#u#s#e#r#", setting.user);
                    htmlText = htmlText.Replace("#p#a#s#s#", setting.password);
                    htmlText = htmlText.Replace("#p#a#g#e#", page);


                    sw.Write(htmlText);




              //  }

                sw.Close();

                System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() + "adminLogIn_tmp.html");
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


        }




    }
}
