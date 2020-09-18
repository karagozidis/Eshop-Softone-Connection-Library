using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using Softone;

namespace S1Custom.Model
{
    class S1Init : TXCode
    {
        private static System.Timers.Timer myTimer;
        public static XSupport myXSupport;

        public override void Initialize()
        {
            base.Initialize();
            myXSupport = this.XSupport;

            Settings settings = Settings.getInstance();
            

            OnTimerElapsed(null, null); //Run first time

            myTimer = new System.Timers.Timer(settings.timerInterval);
            myTimer.Elapsed += new ElapsedEventHandler(OnTimerElapsed);

            myTimer.Interval = settings.timerInterval;
            myTimer.Enabled = true;

           

            /*
            try
            {
                XTable b2bParamTbl = this.XSupport.GetSQLDataSet(
                    "SELECT NAME,VALUE " +
                    "FROM BTOBPARAMTBL WHERE NAME='domain' "
                     );
                settings.domain = b2bParamTbl[0, "VALUE"].ToString();

                b2bParamTbl = this.XSupport.GetSQLDataSet(
                "SELECT NAME,VALUE " +
                "FROM BTOBPARAMTBL WHERE NAME='user' "
                );
                settings.user = b2bParamTbl[0, "VALUE"].ToString();

                b2bParamTbl = this.XSupport.GetSQLDataSet(
                "SELECT NAME,VALUE " +
                "FROM BTOBPARAMTBL WHERE NAME='password' "
                );
                settings.password = b2bParamTbl[0, "VALUE"].ToString();

                b2bParamTbl = this.XSupport.GetSQLDataSet(
               "SELECT NAME,VALUE " +
               "FROM BTOBPARAMTBL WHERE NAME='timerInterval' "
                );
                settings.timerInterval = Convert.ToInt32( b2bParamTbl[0, "VALUE"].ToString() );

            }
            catch (Exception ex)
            {
                this.XSupport.ExecuteSQL(
                   " CREATE TABLE BTOBPARAMTBL "+
                    "    ( "+
                    "    NAME varchar(255), "+
                   "     VALUE varchar(255) "+
                    "    ); "
                    );

                   this.XSupport.ExecuteSQL(
                   " INSERT INTO BTOBPARAMTBL VALUES ('domain',''); " +
                   " INSERT INTO BTOBPARAMTBL VALUES ('user',''); " +
                   " INSERT INTO BTOBPARAMTBL VALUES ('password',''); " +
                   " INSERT INTO BTOBPARAMTBL VALUES ('timerInterval','7200000'); " 
                    );
            } */


        }

        private static void OnTimerElapsed(object source, EventArgs e)
        {
            try
            {
                Settings settings = Settings.getInstance();
              //  myXSupport.ExecuteSQL();

                XTable pRCCategories = myXSupport.GetSQLDataSet(
                       " SELECT  " +
                       " A.SODTYPE, " +
                       " A.MTRL, " +
                       " B.MTRL AS X_15BE3FA0, " +
                       " B.FISCPRD AS X_15BE46F0, " +
                       " ISNULL(B.QTY1,0) AS X_15BE2C20, " +
                       " C.SODTYPE AS X_15BE3AC0, " +
                       " C.MTRL AS X_15BE2E90, " +
                       " C.VARCHAR01 AS X_15BE2F60, " +
                       " C.UTBL01 AS UTBL01, " +
                       " T1.NAME, " +
                       " C.UTBL02 AS UTBL02," +
                       " T2.NAME, " +
                       " C.UTBL03 AS UTBL03, " +
                       " T3.NAME, " +
                       " C.UTBL04 AS UTBL04, " +
                       " T4.NAME, " +
                       " A.CODE, " +
                       " A.NAME, " +
                       " A.CODE1, " +
                       " A.CODE2, " +
                       " A.MTRTYPE, " +
                       " A.MTRTYPE1, " +
                       " A.VAT, " +
                       " A.MTRUNIT1, " +
                       " ISNULL(A.SODISCOUNT,0) AS SODISCOUNT, " +
                       " ISNULL(A.PRICER,0) AS PRICER,  " +
                       "((ISNULL(A.SODISCOUNT,0)/100)*  ISNULL(A.PRICER,0)) AS DISCOUNTVALUE, " +
                       " ISNULL(A.PRICER,0) - ((ISNULL(A.SODISCOUNT,0)/100)*  ISNULL(A.PRICER,0)) AS RETAILWITHDISCOUNT " +
                       " FROM (((((MTRL A LEFT OUTER JOIN MTRDATA B ON A.MTRL=B.MTRL AND B.FISCPRD=2015)  " +
                       " LEFT OUTER JOIN MTREXTRA C ON A.MTRL=C.MTRL) " +
                       " LEFT OUTER JOIN UTBL01 T1 ON T1.CODE = C.UTBL01) " +
                       " LEFT OUTER JOIN UTBL02 T2 ON T2.CODE = C.UTBL02) " +
                       " LEFT OUTER JOIN UTBL03 T3 ON T3.CODE = C.UTBL03) " +
                       " LEFT OUTER JOIN UTBL04 T4 ON T4.CODE = C.UTBL04 " +
                       " WHERE A.COMPANY=1003 AND A.SODTYPE=51 AND A.ISACTIVE = 1 " +
                       " ORDER BY A.CODE,A.MTRL");

                DataTable dTtoXml = new DataTable("PRODUCT");

                //  DataColumn idColumn = 
                dTtoXml.Columns.Add("SKU", typeof(System.String));
                dTtoXml.Columns.Add("TITLE", typeof(System.String));
                dTtoXml.Columns.Add("TITLE2", typeof(System.String));
                dTtoXml.Columns.Add("FEATURE1_ID", typeof(System.String));
                dTtoXml.Columns.Add("FEATURE1_NAME", typeof(System.String));

                dTtoXml.Columns.Add("FEATURE2_ID", typeof(System.String));
                dTtoXml.Columns.Add("FEATURE2_NAME", typeof(System.String));

                dTtoXml.Columns.Add("FEATURE3_ID", typeof(System.String));
                dTtoXml.Columns.Add("FEATURE3_NAME", typeof(System.String));

                dTtoXml.Columns.Add("FEATURE4_ID", typeof(System.String));
                dTtoXml.Columns.Add("FEATURE4_NAME", typeof(System.String));

                dTtoXml.Columns.Add("DISCOUT_PERCENT", typeof(System.String));
                dTtoXml.Columns.Add("RETAIL_PRICE", typeof(System.String));

                dTtoXml.Columns.Add("DISCOUNT_VALUE", typeof(System.String));
                dTtoXml.Columns.Add("RETAIL_WITH_DISCOUNT", typeof(System.String));



                dTtoXml.Columns.Add("STOCK_QTY", typeof(System.String));


                for (int j = 0; j < pRCCategories.Count; j++)
                {
                    dTtoXml.Rows.Add(
                    new object[] { 
                        pRCCategories[j, 17].ToString(), 
                        pRCCategories[j, 18].ToString(),
                        pRCCategories[j, 8].ToString() , 
                        pRCCategories[j, 9].ToString() ,
                        pRCCategories[j, 10].ToString(), 
                        pRCCategories[j, 11].ToString(),
                        pRCCategories[j, 12].ToString(), 
                        pRCCategories[j, 13].ToString(),
                        pRCCategories[j, 14].ToString(), 
                        pRCCategories[j, 15].ToString(),
                        pRCCategories[j, 16].ToString(), 
                        pRCCategories[j, 25].ToString(), 
                        pRCCategories[j, 26].ToString(),
                        pRCCategories[j, 27].ToString(), 
                        pRCCategories[j, 28].ToString(),
                        pRCCategories[j, 5].ToString()
                        });
                }

               // dTtoXml.AcceptChanges();
               // dTtoXml.WriteXml(settings.outputPath);

               /* if (settings.ftpDomain != " " && settings.ftpDomain != "" && settings.ftpDomain != "~")
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(settings.user, settings.password);
                       client.UploadFile(settings.ftpDomain, settings.outputPath);
                    }
                } */

            }
            catch (Exception ex)
            {
                //  String path = "sdsds";
                //  path = System.IO.Path.GetTempPath() + "productsXml.xml";
                //  MessageBox.Show(System.IO.Path.GetTempPath() + "Productslog.xml");
                //  using (StreamWriter w = File.AppendText(@"C:\products_log.txt"))
               // using (StreamWriter w = File.AppendText(System.IO.Path.GetTempPath() + "productsLog.xml"))
              //  {
                    //  w.WriteLine(ex.Message);
               // }
            }


        }



    }
}
