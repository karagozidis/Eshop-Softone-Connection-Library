using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary4
{
    public static class VWEBEXCEPTION
    {
        public static void SaveToLog(String Title, String Message)
        {
            String Timestamp = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");

            String SQL = "INSERT INTO CCCVWEBEXCEPTIONLOG " + 
                " (MESSAGE,SMALLMESSAGE,EXCEPTIONDATE) "+
                " VALUES "+
                " ('" + Message.Replace("'", "΄") + "' ,'" + Title.Replace("'", "΄") + "','" + Timestamp + "');";

            S1Custom.Model.S1Init.myXSupport.ExecuteSQL(SQL);
        }


    }
}
