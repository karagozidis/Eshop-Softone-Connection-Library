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
        public String AdminPath = "";

        public int timerInterval = 0;// 7200000;

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
       
         public String ItemTitle1 = "";
         public String ItemDescr1 = "";
         public String ItemTitle2 = "";
         public String ItemDescr2 = "";

         public String ItemUpdateTitle = "";
         public String ItemUpdateDescr = "";

         public String TrdrUpdateOnPost = "";
         public String ItemUpdateOnPost = "";

         public String WHouse = "";
         public String OrderWebRel = "";
        
         public String WebDateFormat = "";
         public String Detaxation = ""; 

         public String ItemCateg = "";

         public String ItemExtra1 = "";
         public String ItemExtra2 = "";
         public String ItemExtra3 = "";

         public int ItemDaysTransactions = 0;
         public bool ItemUpdateCharacteristicsQty = false; 

        
        private Settings() {
         
               try
                {
                    XTable b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                        "SELECT NAME,VALUE " +
                        "FROM CCCBTOBPARAMTBL WHERE NAME='domain' "
                         );
                    this.domain = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='AdminPath' "
                    );
                    this.AdminPath = b2bParamTbl[0, "VALUE"].ToString();
                    

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='user' "
                    );
                    this.user = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='password' "
                    );
                    this.password = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='orderSeries' "
                    );
                    this.orderSeries = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='timerInterval' "
                    );
                    this.timerInterval = Convert.ToInt32(
                        S1Custom.Properties.SettingsPerUsr.Default["TimeInterval"].ToString() 
                        );

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='EXPN' "
                    );
                    this.EXPN = b2bParamTbl[0, "VALUE"].ToString();


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='TRDR_NAME_FIELD' "
                    );
                    this.TRDR_NAME_FIELD = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='TRDR_LNAME_FIELD' "
                    );
                    this.TRDR_LNAME_FIELD = b2bParamTbl[0, "VALUE"].ToString();
                       
       
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='TRDR_PASSWORD_FIELD' "
                    );
                    this.TRDR_PASSWORD_FIELD = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='TRDR_ON_WEB' "
                    );
                    this.TRDR_ON_WEB = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ITEM_ON_WEB' "
                    );
                    this.ITEM_ON_WEB = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ITEM_PRICE' "
                    );
                    this.ITEM_PRICE = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='imagesFtpDomain' "
                    );
                    this.imagesFtpDomain = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='imagesFtpUser' "
                    );
                    this.imagesFtpUser = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='imagesFtpPassword' "
                    );
                    this.imagesFtpPassword = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='images_domain' "
                    );
                    this.images_domain = b2bParamTbl[0, "VALUE"].ToString();


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemTitle1' "
                    );
                    this.ItemTitle1 = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemDescr1' "
                    );
                    this.ItemDescr1 = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemTitle2' "
                    );
                    this.ItemTitle2 = b2bParamTbl[0, "VALUE"].ToString();

                    
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemDescr2' "
                    );
                    this.ItemDescr2 = b2bParamTbl[0, "VALUE"].ToString(); 


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemUpdateTitle' "
                    );
                    this.ItemUpdateTitle = b2bParamTbl[0, "VALUE"].ToString(); 

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemUpdateDescr' "
                    );
                    this.ItemUpdateDescr = b2bParamTbl[0, "VALUE"].ToString(); 



                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='TrdrUpdateOnPost' "
                    );
                    this.TrdrUpdateOnPost = b2bParamTbl[0, "VALUE"].ToString(); 


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemUpdateOnPost' "
                    );
                    this.ItemUpdateOnPost = b2bParamTbl[0, "VALUE"].ToString(); 


                   
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='WHouse' "
                    );
                    this.WHouse = b2bParamTbl[0, "VALUE"].ToString(); 

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='OrderWebRel' "
                    );
                    this.OrderWebRel = b2bParamTbl[0, "VALUE"].ToString(); 


                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='WebDateFormat' "
                    );
                    this.WebDateFormat = b2bParamTbl[0, "VALUE"].ToString(); 

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='Detaxation' "
                    );
                    this.Detaxation = b2bParamTbl[0, "VALUE"].ToString(); 

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemCateg' "
                    );
                    this.ItemCateg = b2bParamTbl[0, "VALUE"].ToString();



                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                     "SELECT NAME,VALUE " +
                     "FROM CCCBTOBPARAMTBL WHERE NAME='ItemExtra1' "
                     );
                    this.ItemExtra1 = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemExtra2' "
                    );
                    this.ItemExtra2 = b2bParamTbl[0, "VALUE"].ToString();

                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemExtra3' "
                    );
                    this.ItemExtra3 = b2bParamTbl[0, "VALUE"].ToString(); 


                    try
                    {
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemDaysTransactions' ");
                  
                    int value = int.Parse(b2bParamTbl[0, "VALUE"].ToString());
                    this.ItemDaysTransactions = value;
                    }
                    catch {}

                     
                   
                    try
                    {
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemDaysTransactions' ");
                  
                    int value = int.Parse(b2bParamTbl[0, "VALUE"].ToString());
                    this.ItemDaysTransactions = value;
                    }
                    catch {}



                                       try
                    {
                    b2bParamTbl = Model.S1Init.myXSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM CCCBTOBPARAMTBL WHERE NAME='ItemUpdateCharacteristicsQty' ");
                  
                    String value = b2bParamTbl[0, "VALUE"].ToString();
                    if(value == "0") this.ItemUpdateCharacteristicsQty = true;
                    else this.ItemUpdateCharacteristicsQty = true;
                    }
                    catch {}

                   

                   

                }
                catch (Exception ex)
                {
                 /*   Model.S1Init.myXSupport.ExecuteSQL(
                       " CREATE TABLE CCCBTOBPARAMTBL  " +
                       "    (                          " +
                       "    NAME varchar(255),         " +
                       "     VALUE varchar(255)        " +
                       "    );                         "
                        );

                 Model.S1Init.myXSupport.ExecuteSQL(
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('domain',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('user',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('password',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('timerInterval','0'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('orderSeries','7021'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('EXPN','104'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('TRDR_NAME_FIELD','NAME'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('TRDR_LNAME_FIELD','NAME'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('TRDR_PASSWORD_FIELD','AFM'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ITEM_PRICE','PRICER'); "+
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('TRDR_ON_WEB',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ITEM_ON_WEB',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('imagesFtpDomain',''); " + 
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('imagesFtpUser',''); "+
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('imagesFtpPassword',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('images_domain',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('AdminPath',''); " + 
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemTitle1',''); " + 
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemDescr1',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemTitle2',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemDescr2',''); " + 
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemUpdateTitle',''); " + 
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemUpdateDescr',''); " + 
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('TrdrUpdateOnPost',''); "  +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemUpdateOnPost',''); "  +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('WHouse',''); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('OrderWebRel',''); "   +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('WebDateFormat','yyyy-MM-dd HH:mm:ss'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('Detaxation','1'); " +
                    " INSERT INTO CCCBTOBPARAMTBL VALUES ('ItemCateg','UTBL01'); "  
                   
                  ); */



                } 


        }

        public void updateSetting(String name, String value)
        {
            Model.S1Init.myXSupport.ExecuteSQL(
                       " DELETE FROM CCCBTOBPARAMTBL WHERE NAME = '" + name + "'; "
                        );

            Model.S1Init.myXSupport.ExecuteSQL(
                    " INSERT INTO CCCBTOBPARAMTBL (VALUE,NAME) VALUES ('" + value + "','" + name + "')   "
                     );
          /*  Model.S1Init.myXSupport.ExecuteSQL(
                    " UPDATE CCCBTOBPARAMTBL SET VALUE = '" + value + "' WHERE NAME = '" + name + "'; " 
                     ); */
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



    }
}
