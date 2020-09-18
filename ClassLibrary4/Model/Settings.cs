using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using Softone;

namespace S1Custom
{
    class Settings 
    {
        private static Settings instance = null;
        public String domain = "";
        public String user = "";
        public String password = "";
        public int timerInterval = 7200000;

        public String imagesFtpDomain = "";
        public String imagesFtpUser = "";
        public String imagesFtpPassword = "";
        public String images_domain = "";

        public String orderSeries = "7021";
        public String EXPN = "104";
        
        public String TRDR_NAME_FIELD = "NAME";
        public String TRDR_LNAME_FIELD = "NAME";
        public String TRDR_PASSWORD_FIELD = "AFM";
        public String TRDR_ON_WEB = "";
        public String ITEM_ON_WEB = "";

        public String ITEM_PRICE = "PRICER";
       


        private Settings() {
         
               try
                {
                    XTable b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                        "SELECT NAME,VALUE " +
                        "FROM BTOBPARAMTBL WHERE NAME='domain' "
                         );
                    this.domain = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='user' "
                    );
                    this.user = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='password' "
                    );
                    this.password = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='orderSeries' "
                    );
                    this.orderSeries = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='timerInterval' "
                    );
                    this.timerInterval = Convert.ToInt32( b2bParamTbl[0, "VALUE"].ToString() );

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='EXPN' "
                    );
                    this.EXPN = b2bParamTbl[0, "VALUE"].ToString();


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='TRDR_NAME_FIELD' "
                    );
                    this.TRDR_NAME_FIELD = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='TRDR_LNAME_FIELD' "
                    );
                    this.TRDR_LNAME_FIELD = b2bParamTbl[0, "VALUE"].ToString();
                       
       
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='TRDR_PASSWORD_FIELD' "
                    );
                    this.TRDR_PASSWORD_FIELD = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='TRDR_ON_WEB' "
                    );
                    this.TRDR_ON_WEB = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='ITEM_ON_WEB' "
                    );
                    this.ITEM_ON_WEB = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='ITEM_PRICE' "
                    );
                    this.ITEM_PRICE = b2bParamTbl[0, "VALUE"].ToString();



                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='imagesFtpDomain' "
                    );
                    this.imagesFtpDomain = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='imagesFtpUser' "
                    );
                    this.imagesFtpUser = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='imagesFtpPassword' "
                    );
                    this.imagesFtpPassword = b2bParamTbl[0, "VALUE"].ToString();


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='images_domain' "
                    );
                    this.images_domain = b2bParamTbl[0, "VALUE"].ToString();

                }
                catch (Exception ex)
                {
                    Model.S1Init.myXSupport.ExecuteSQL(
                       " CREATE TABLE BTOBPARAMTBL " +
                        "    ( " +
                        "    NAME varchar(255), " +
                       "     VALUE varchar(255) " +
                        "    ); "
                        );

                    Model.S1Init.myXSupport.ExecuteSQL(
                    " INSERT INTO BTOBPARAMTBL VALUES ('domain',''); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('user',''); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('password',''); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('timerInterval','7200000'); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('orderSeries','7021'); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('EXPN','104'); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('TRDR_NAME_FIELD','NAME'); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('TRDR_LNAME_FIELD','NAME'); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('TRDR_PASSWORD_FIELD','AFM'); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('ITEM_PRICE','PRICER'); "+
                    " INSERT INTO BTOBPARAMTBL VALUES ('TRDR_ON_WEB',''); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('ITEM_ON_WEB',''); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('imagesFtpDomain',''); " + 
                    " INSERT INTO BTOBPARAMTBL VALUES ('imagesFtpUser',''); "+
                    " INSERT INTO BTOBPARAMTBL VALUES ('imagesFtpPassword',''); " +
                    " INSERT INTO BTOBPARAMTBL VALUES ('images_domain',''); "
                    
                     );

                } 


        }

        public void updateSetting(String name, String value)
        {
            Model.S1Init.myXSupport.ExecuteSQL(
                    " UPDATE BTOBPARAMTBL SET VALUE = '" + value + "' WHERE NAME = '" + name + "'; " 
                     );
        }


        public static Settings getInstance()
        {
         if (instance == null)
                 {
                     instance = new Settings();
                  //   instance.domain = "aaa";

                 }
           return instance;
        }

      //  public static Settings Instance
          // {
            //  get 
             // {
              //   if (instance == null)
              //   {
              //       instance = new Settings();
              //       instance.domain = "aaa";

                // }
               //  return instance;
             // }
     //      }




    }
}
