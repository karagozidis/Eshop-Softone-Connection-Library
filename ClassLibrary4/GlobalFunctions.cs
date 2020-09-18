using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary4.MDL;
using S1Custom;
using S1Custom.Model;
using Softone;

namespace ClassLibrary4
{
    public static class GlobalFunctions
    {
        
        public static void updateQTYS(String MTRL)
        {
            try
            {

                Settings settings = Settings.getInstance();
                String strQTY = "";
                String FILTER_CHECKBOX = "";
                S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();

                String MTRL_SQL = "";
                if (!MTRL.Equals(""))
                {
                    MTRL_SQL = " AND A.MTRL=" + MTRL + " ";
                }
               


                if (!settings.ITEM_ON_WEB.Equals(""))
                {
                    FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1";
                }
                String s = S1Init.myXSupport.ConnectionInfo.YearId.ToString();
                XTable QTYREsults = S1Init.myXSupport.GetSQLDataSet(
                    " SELECT   " +
                    " A.MTRL,  " +
                    " ISNULL(B.QTY1,0) AS QTY,  " +
                    " A.CODE  " +
                    " FROM ((MTRL A   " +
                    " LEFT OUTER JOIN MTRDATA B ON A.MTRL=B.MTRL )  " +
                    " LEFT OUTER JOIN MTREXTRA ME ON A.MTRL = ME.MTRL ) " +
                    " WHERE A.COMPANY=  " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                    " AND B.FISCPRD=  " + S1Init.myXSupport.ConnectionInfo.YearId.ToString() +
                    " AND A.SODTYPE=51   " +
                     FILTER_CHECKBOX +
                     MTRL_SQL + 
                    " ORDER BY A.CODE,A.MTRL  ");

                for (int j = 0; j < QTYREsults.Count; j++)
                {
                    strQTY += "&QTYS[" + QTYREsults[j, "CODE"] + "]=" + QTYREsults[j, "QTY"];
                }

                itemHttp.syncQTY(strQTY);


            }
            catch (Exception ex)
            {

            }
        }



        public static void updateQTYsByMtrlsOnTransactions()
        {
            try
            {
                Settings settings = Settings.getInstance();
                String strQTY = "";
                String FILTER_CHECKBOX = "";
                S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();


                if (!settings.ITEM_ON_WEB.Equals(""))
                {
                    FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1";
                }
                String s = S1Init.myXSupport.ConnectionInfo.YearId.ToString();
                XTable QTYREsults = S1Init.myXSupport.GetSQLDataSet(
                    " SELECT   " +
                    " A.MTRL,  " +
                    " ISNULL(B.QTY1,0) AS QTY,  " +
                    " A.CODE  " +
                    " FROM (MTRL A   " +
                    " LEFT OUTER JOIN MTRDATA B ON A.MTRL=B.MTRL )  " +
                    " WHERE A.COMPANY=  " + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                    " AND B.FISCPRD=  " + S1Init.myXSupport.ConnectionInfo.YearId.ToString() +
                    " AND A.MTRL IN (SELECT ML.MTRL FROM MTRLINES ML INNER JOIN FINDOC F ON F.FINDOC = ML.FINDOC WHERE F.TRNDATE >  DATEADD(day, -15, GETDATE()) ) " + 
                    " AND A.SODTYPE=51   " +
                     FILTER_CHECKBOX +
                    " ORDER BY A.CODE,A.MTRL  ");

                for (int j = 0; j < QTYREsults.Count; j++)
                {
                    strQTY += "&QTYS[" + QTYREsults[j, "CODE"] + "]=" + QTYREsults[j, "QTY"];
                }

                itemHttp.syncQTY(strQTY);

            }
            catch (Exception ex)
            {

            }
        }



        /*
        public static void syncMtrl()
        {
            S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();
            string[,] PRICERPRC = new string[12, 2];
            String CODE = "", MTRL = "", NAME = "", NAME2 = "", DESCR = "", DESCR2 = "", ITEM_PRICE = "";
            String NAMEpREFIX = "", NAME2pREFIX = "", DESCRpREFIX = "", DESCR2pREFIX = "";
            String CATEG_NAME = "-1", CATEG_ID = "-1", QTY = "";
            Settings settings = Settings.getInstance();
            String FILTER_CHECKBOX = "";
            ImageUploader imageUp = new ImageUploader();
            String MTRMANFCTR = "";

            XTable pRCCategories = S1Init.myXSupport.GetSQLDataSet(
            "SELECT A.COMPANY,A.PRCCATEGORY,A.CODE,A.NAME,A.ACNMSK,A.ISACTIVE,A.PRICEZONE " +
            "FROM PRCCATEGORY A WHERE A.COMPANY=" + S1Init.myXSupport.ConnectionInfo.CompanyId + " ORDER BY A.PRCCATEGORY"
             );

            if (!settings.ITEM_ON_WEB.Equals(""))
            {
                FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1";
            }

            if (settings.ItemTitle1.Contains("VARCHAR")) NAMEpREFIX = "ME.";
            else NAMEpREFIX = "M.";

            if (settings.ItemDescr1.Contains("VARCHAR")) DESCRpREFIX = "ME.";
            else DESCRpREFIX = "M.";

            if (settings.ItemTitle2.Contains("VARCHAR")) NAME2pREFIX = "ME.";
            else NAME2pREFIX = "M.";

            if (settings.ItemDescr2.Contains("VARCHAR")) DESCR2pREFIX = "ME.";
            else DESCR2pREFIX = "M.";


            XTable MTRLS = S1Init.myXSupport.GetSQLDataSet(
             " SELECT " +
             " M.MTRL AS MTRL, " +
             " M.CODE , " +
             " M." + settings.ITEM_PRICE + ", " +
             " M." + settings.ITEM_PRICE + "01, " +
             " M." + settings.ITEM_PRICE + "02, " +
             " M." + settings.ITEM_PRICE + "03, " +
             " M." + settings.ITEM_PRICE + "04, " +
             " M." + settings.ITEM_PRICE + "05, " +
             " M." + settings.ITEM_PRICE + "06, " +
             " M." + settings.ITEM_PRICE + "07, " +
             " M." + settings.ITEM_PRICE + "08, " +
             " M." + settings.ITEM_PRICE + "09, " +
             " M." + settings.ITEM_PRICE + "10, " +
             " M." + settings.ITEM_PRICE + "11, " +
             " M." + settings.ITEM_PRICE + "12, " +
             " G.CODE ,  " +
             " G.NAME , " +

             NAMEpREFIX + settings.ItemTitle1 + " AS " + settings.ItemTitle1 + "_Lang1 ," +
             DESCRpREFIX + settings.ItemDescr1 + " AS " + settings.ItemDescr1 + "_Desc1 ," +
             NAME2pREFIX + settings.ItemTitle2 + " AS " + settings.ItemTitle2 + "_Lang2 ," +
             DESCR2pREFIX + settings.ItemDescr2 + " AS " + settings.ItemDescr2 + "_Desc2 ," +
             " B.QTY1, " +
             " M.MTRMANFCTR  " +
             " FROM (( MTRL M LEFT OUTER JOIN MTRGROUP G ON M.MTRGROUP = G.MTRGROUP " +
             " AND G.SODTYPE = 51  " +
             " AND G.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId + " ) " +
             " LEFT OUTER JOIN MTREXTRA ME ON M.MTRL = ME.MTRL ) " +
             " LEFT OUTER JOIN MTRDATA B ON M.MTRL=B.MTRL AND B.FISCPRD= " + S1Init.myXSupport.ConnectionInfo.YearId.ToString() +
             " WHERE M.SODTYPE = 51 " +
             " AND M.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId +
              FILTER_CHECKBOX
             );

            int zone;
            PRICERPRC = new string[12, 2];
            for (int j = 0; j < pRCCategories.Count; j++)
            {
                zone = int.Parse(pRCCategories[j, 7].ToString());
                PRICERPRC[zone - 1, 0] = pRCCategories[j, 2].ToString();
            }

            for (int i = 0; i < MTRLS.Count; i++)
            {
                int j = 0;
                CATEG_NAME = "-1";
                CATEG_ID = "-1";


                CODE = "";
                if (!DBNull.Value.Equals(MTRLS[i, "CODE"]))
                {
                    CODE = (String)MTRLS[i, "CODE"];
                }

                MTRL = "";
                if (!DBNull.Value.Equals(MTRLS[i, "MTRL"]))
                {
                    MTRL = (String)MTRLS[i, "MTRL"].ToString();
                }

                NAME = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemTitle1 + "_Lang1"]))
                {
                    NAME = (String)MTRLS[i, settings.ItemTitle1 + "_Lang1"];
                }

                DESCR = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemDescr1 + "_Desc1"]))
                {
                    DESCR = (String)MTRLS[i, settings.ItemDescr1 + "_Desc1"];
                }

                NAME2 = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemTitle2 + "_Lang2"]))
                {
                    NAME2 = (String)MTRLS[i, settings.ItemTitle2 + "_Lang2"];
                }

                DESCR2 = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemDescr2 + "_Desc2"]))
                {
                    DESCR2 = (String)MTRLS[i, settings.ItemDescr2 + "_Desc2"];
                }

                MTRMANFCTR = "";
                if (!DBNull.Value.Equals(MTRLS[i, "MTRMANFCTR"]))
                {
                    try
                    {
                        MTRMANFCTR = (String)MTRLS[i, "MTRMANFCTR"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }

                QTY = "0";
                if (!DBNull.Value.Equals(MTRLS[i, "QTY1"]))
                {
                    try
                    {
                        QTY = (String)MTRLS[i, "QTY1"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }


                ITEM_PRICE = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE]))
                {
                    ITEM_PRICE = (String)MTRLS[i, settings.ITEM_PRICE].ToString();
                }


                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "01"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "01"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "02"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "02"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[j, settings.ITEM_PRICE + "03"]))
                {
                    PRICERPRC[i, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "03"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[j, settings.ITEM_PRICE + "04"]))
                {
                    PRICERPRC[i, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "04"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "05"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "05"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "06"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "06"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "07"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "07"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "08"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "08"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "09"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "09"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "10"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "10"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "11"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "11"].ToString();
                    j++;
                }
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "12"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "12"].ToString();
                    j++;
                }

                itemHttp.syncMTRL(CODE, NAME, NAME2, DESCR, DESCR2, ITEM_PRICE, PRICERPRC, j, CATEG_NAME, CATEG_ID, QTY, MTRMANFCTR, "" ,"","");
                imageUp.uploadItemImage(MTRL, CODE);
               
            }
       
        } */


        public static void syncMtrl(ProgressBar loadingProgressBar, String MTRL_FILTER)
        {
            S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();
            string[,] PRICERPRC = new string[12, 2];
            String CODE = "";
            String MTRL = "";
            String NAME = "";
            String NAME2 = "";
            String DESCR = "";
            String DESCR2 = "";
            String ITEM_PRICE = "";
            String NAMEpREFIX = "";
            String NAME2pREFIX = "";
            String DESCRpREFIX = "";
            String DESCR2pREFIX = "";
            String WEIGHT = "";
            String CATEG_NAME = "-1";
            String CATEG_ID = "-1";
            String CATEG_SQl = "";
            

            String QTY = "";
            Settings settings = Settings.getInstance();
            String FILTER_CHECKBOX = "";
            ImageUploader imageUp = new ImageUploader();

            String MTRMANFCTR = "";

            String ItemExtra1 = "";
            String ItemExtra2 = "";
            String ItemExtra3 = "";
            String ItemExtra1Sql = "";
            String ItemExtra2Sql = "";
            String ItemExtra3Sql = "";
            String MTRUNIT1 = "";
            String VAT = "";
            String SODISCOUNT = "";
            String RELITEM = "";
            String EXPN1 = "";
            String EXPN2 = "";
            String EXPN3 = "";
            String EXPVAL1 = "";
            String EXPVAL2 = "";
            String EXPVAL3 = "";


            String MTRL_SQL = "";
            if (!MTRL_FILTER.Equals(""))
            {
                MTRL_SQL = " AND M.MTRL=" + MTRL_FILTER + " ";
            }


            if (loadingProgressBar != null)
            {
                loadingProgressBar.Maximum = 2;
                loadingProgressBar.Value = 0;
                loadingProgressBar.Step = 1;
                loadingProgressBar.PerformStep();
            }

            XTable pRCCategories = S1Init.myXSupport.GetSQLDataSet(
            "SELECT A.COMPANY,A.PRCCATEGORY,A.CODE,A.NAME,A.ACNMSK,A.ISACTIVE,A.PRICEZONE " +
            "FROM PRCCATEGORY A WHERE A.COMPANY=" + S1Init.myXSupport.ConnectionInfo.CompanyId + " ORDER BY A.PRCCATEGORY"
             );

            if (settings.ItemCateg.Contains("VARCHAR") || settings.ItemCateg.Contains("UTBL") ||
                    settings.ItemCateg.Contains("NUM")) 
                CATEG_SQl = "ME." + settings.ItemCateg + ",";
            else CATEG_SQl = "M."+settings.ItemCateg + ",";

            if (!settings.ITEM_ON_WEB.Equals("") && MTRL_FILTER == "" )
            {
                FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1";
            }

            if (settings.ItemTitle1.Contains("VARCHAR")) NAMEpREFIX = "ME.";
            else NAMEpREFIX = "M.";

            if (settings.ItemDescr1.Contains("VARCHAR")) DESCRpREFIX = "ME.";
            else DESCRpREFIX = "M.";

            if (settings.ItemTitle2.Contains("VARCHAR")) NAME2pREFIX = "ME.";
            else NAME2pREFIX = "M.";

            if (settings.ItemDescr2.Contains("VARCHAR")) DESCR2pREFIX = "ME.";
            else DESCR2pREFIX = "M.";


            if (!settings.ItemExtra1.Equals(""))
            {
                if (settings.ItemExtra1.Contains("VARCHAR") || settings.ItemExtra1.Contains("UTBL") ||
                    settings.ItemExtra1.Contains("NUM") || settings.ItemExtra1.Contains("BOOL") ||
                    settings.ItemExtra1.Contains("DATE"))
                {
                    ItemExtra1Sql = "ME." + settings.ItemExtra1 + ",";
                }

                else if ( !settings.ItemExtra1.Equals("") )
                {
                    ItemExtra1Sql = "M." + settings.ItemExtra1 + ",";
                }
            }


            if (!settings.ItemExtra2.Equals(""))
            {
                if (settings.ItemExtra2.Contains("VARCHAR") || settings.ItemExtra2.Contains("UTBL") ||
                    settings.ItemExtra2.Contains("NUM") || settings.ItemExtra2.Contains("BOOL") ||
                    settings.ItemExtra2.Contains("DATE"))
                {
                    ItemExtra2Sql = "ME." + settings.ItemExtra2 + ",";
                }

                else if (!settings.ItemExtra2.Equals(""))
                {
                    ItemExtra2Sql = "M." + settings.ItemExtra2 + ",";
                }
            }

            if (!settings.ItemExtra3.Equals(""))
            {
                if (settings.ItemExtra3.Contains("VARCHAR") || settings.ItemExtra3.Contains("UTBL") ||
                    settings.ItemExtra3.Contains("NUM") || settings.ItemExtra3.Contains("BOOL") ||
                    settings.ItemExtra3.Contains("DATE"))
                {
                    ItemExtra3Sql = "ME." + settings.ItemExtra3 + ",";
                }

                else if (!settings.ItemExtra3.Equals(""))
                {
                    ItemExtra3Sql = "M." + settings.ItemExtra3 + ",";
                }
            }



            XTable MTRLS = S1Init.myXSupport.GetSQLDataSet(
             " SELECT " +
             " M.MTRL AS MTRL, " +
             " M.CODE , " +
             " M.WEIGHT , " +
             " M." + settings.ITEM_PRICE + ", " +
             " M." + settings.ITEM_PRICE + "01, " +
             " M." + settings.ITEM_PRICE + "02, " +
             " M." + settings.ITEM_PRICE + "03, " +
             " M." + settings.ITEM_PRICE + "04, " +
             " M." + settings.ITEM_PRICE + "05, " +
             " M." + settings.ITEM_PRICE + "06, " +
             " M." + settings.ITEM_PRICE + "07, " +
             " M." + settings.ITEM_PRICE + "08, " +
             " M." + settings.ITEM_PRICE + "09, " +
             " M." + settings.ITEM_PRICE + "10, " +
             " M." + settings.ITEM_PRICE + "11, " +
             " M." + settings.ITEM_PRICE + "12, " +
             " G.CODE ,  " +
             " G.NAME , " +
             " M.MTRUNIT1," +
             " M.VAT," +
             " M.SODISCOUNT," +
             
             " RL.CODE AS REL ," +
             " M.EXPN1," +
             " M.EXPN2," +
             " M.EXPN3," +
             " M.EXPVAL1," +
             " M.EXPVAL2 ," +
             " M.EXPVAL3 ," +

             CATEG_SQl+
             NAMEpREFIX + settings.ItemTitle1 + " AS " + settings.ItemTitle1 + "_Lang1 ," +
             DESCRpREFIX + settings.ItemDescr1 + " AS " + settings.ItemDescr1 + "_Desc1 ," +
             NAME2pREFIX + settings.ItemTitle2 + " AS " + settings.ItemTitle2 + "_Lang2 ," +
             DESCR2pREFIX + settings.ItemDescr2 + " AS " + settings.ItemDescr2 + "_Desc2 ," +

             ItemExtra1Sql +
             ItemExtra2Sql +
             ItemExtra3Sql +

             " B.QTY1, " +
             " M.MTRMANFCTR  " +
             " FROM ((( MTRL M LEFT OUTER JOIN MTRGROUP G ON M.MTRGROUP = G.MTRGROUP " +
             " AND G.SODTYPE = 51  " +
             " AND G.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId + " ) " +
             " LEFT OUTER JOIN MTREXTRA ME ON M.MTRL = ME.MTRL ) " +
             " LEFT OUTER JOIN MTRDATA B ON M.MTRL=B.MTRL AND B.FISCPRD= " + S1Init.myXSupport.ConnectionInfo.YearId.ToString() + " ) " +
             " LEFT OUTER JOIN MTRL RL ON M.RELITEM = RL.MTRL" +
             " WHERE M.SODTYPE = 51 " +
             " AND M.COMPANY = " + S1Init.myXSupport.ConnectionInfo.CompanyId +
             " " + FILTER_CHECKBOX + 
             " " + MTRL_SQL
             );

            int zone;
            PRICERPRC = new string[12, 2];
            for (int j = 0; j < pRCCategories.Count; j++)
            {
                zone = int.Parse(pRCCategories[j, 7].ToString());
                PRICERPRC[zone - 1, 0] = pRCCategories[j, 2].ToString();
            }


            if (loadingProgressBar != null)
            {
                if (MTRLS.Count > 0)
                {
                    loadingProgressBar.Maximum = MTRLS.Count;
                }
                loadingProgressBar.Value = 0;
            }



            for (int i = 0; i < MTRLS.Count; i++)
            {

                if (loadingProgressBar != null)
                {
                    loadingProgressBar.PerformStep();
                }

                int j = 0;
                CATEG_NAME = "-1";
                CATEG_ID = "-1";

                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemCateg]))
                {
                    CATEG_ID = (String)MTRLS[i, settings.ItemCateg].ToString();
                    if (CATEG_ID.Equals("")) CATEG_ID = "-1";
                }

                CODE = "";
                if (!DBNull.Value.Equals(MTRLS[i, "CODE"]))
                {
                    CODE = (String)MTRLS[i, "CODE"].ToString();
                }

                MTRL = "";
                if (!DBNull.Value.Equals(MTRLS[i, "MTRL"]))
                {
                    MTRL = (String)MTRLS[i, "MTRL"].ToString();
                }

                NAME = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemTitle1 + "_Lang1"]))
                {
                    NAME = (String)MTRLS[i, settings.ItemTitle1 + "_Lang1"].ToString();
                }

                DESCR = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemDescr1 + "_Desc1"]))
                {
                    DESCR = (String)MTRLS[i, settings.ItemDescr1 + "_Desc1"].ToString();
                }

                NAME2 = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemTitle2 + "_Lang2"]))
                {
                    NAME2 = (String)MTRLS[i, settings.ItemTitle2 + "_Lang2"].ToString();
                }

                DESCR2 = "";
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemDescr2 + "_Desc2"]))
                {
                    DESCR2 = (String)MTRLS[i, settings.ItemDescr2 + "_Desc2"].ToString();
                }

                WEIGHT = "";
                if (!DBNull.Value.Equals(MTRLS[i, "WEIGHT"]))
                {
                    WEIGHT = (String)MTRLS[i, "WEIGHT"].ToString();
                }

                MTRUNIT1 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "MTRUNIT1"]))
                {
                    MTRUNIT1 = (String)MTRLS[i, "MTRUNIT1"].ToString();
                }

                VAT = "";
                if (!DBNull.Value.Equals(MTRLS[i, "VAT"]))
                {
                    VAT = (String)MTRLS[i, "VAT"].ToString();
                }

                SODISCOUNT = "";
                if (!DBNull.Value.Equals(MTRLS[i, "SODISCOUNT"]))
                {
                    SODISCOUNT = (String)MTRLS[i, "SODISCOUNT"].ToString();
                }

                ItemExtra1 = "";
                if (settings.ItemExtra1 !="")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemExtra1]))
                {
                    ItemExtra1 = (String)MTRLS[i, settings.ItemExtra1].ToString();
                }

                ItemExtra2 = "";
                if (settings.ItemExtra2 != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemExtra2]))
                {
                    ItemExtra2 = (String)MTRLS[i, settings.ItemExtra2].ToString();
                }

                ItemExtra3 = "";
                if (settings.ItemExtra3 != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ItemExtra3]))
                {
                    ItemExtra3 = (String)MTRLS[i, settings.ItemExtra3].ToString();
                }


                RELITEM = "";
                if (!DBNull.Value.Equals(MTRLS[i, "REL"]))
                {
                    RELITEM = (String)MTRLS[i, "REL"].ToString();
                }

                EXPN1 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "EXPN1"]))
                {
                    EXPN1 = (String)MTRLS[i, "EXPN1"].ToString();
                }

                EXPN2 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "EXPN2"]))
                {
                    EXPN2 = (String)MTRLS[i, "EXPN2"].ToString();
                }

                EXPN3 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "EXPN3"]))
                {
                    EXPN3 = (String)MTRLS[i, "EXPN3"].ToString();
                }

                EXPVAL1 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "EXPVAL1"]))
                {
                    EXPVAL1 = (String)MTRLS[i, "EXPVAL1"].ToString();
                }

                EXPVAL2 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "EXPVAL2"]))
                {
                    EXPVAL2 = (String)MTRLS[i, "EXPVAL2"].ToString();
                }

                EXPVAL3 = "";
                if (!DBNull.Value.Equals(MTRLS[i, "EXPVAL3"]))
                {
                    EXPVAL3 = (String)MTRLS[i, "EXPVAL3"].ToString();
                }

                MTRMANFCTR = "";
                if (!DBNull.Value.Equals(MTRLS[i, "MTRMANFCTR"]))
                {
                    try
                    {
                        MTRMANFCTR = (String)MTRLS[i, "MTRMANFCTR"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }

                QTY = "0";
                if (!DBNull.Value.Equals(MTRLS[i, "QTY1"]))
                {
                    try
                    {
                        QTY = (String)MTRLS[i, "QTY1"].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }


                ITEM_PRICE = "";
                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE]))
                {
                    ITEM_PRICE = (String)MTRLS[i, settings.ITEM_PRICE].ToString();
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "01"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "01"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "02"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "02"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[j, settings.ITEM_PRICE + "03"]))
                {
                    PRICERPRC[i, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "03"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[j, settings.ITEM_PRICE + "04"]))
                {
                    PRICERPRC[i, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "04"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "05"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "05"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "06"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "06"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "07"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "07"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "08"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "08"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "09"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "09"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "10"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "10"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "11"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "11"].ToString();
                    j++;
                }

                if (settings.ITEM_PRICE != "")
                if (!DBNull.Value.Equals(MTRLS[i, settings.ITEM_PRICE + "12"]))
                {
                    PRICERPRC[j, 1] = (String)MTRLS[i, settings.ITEM_PRICE + "12"].ToString();
                    j++;
                }

                itemHttp.syncMTRL(CODE, NAME, NAME2, DESCR, DESCR2, ITEM_PRICE,
                   PRICERPRC, j, CATEG_NAME, CATEG_ID, QTY, MTRMANFCTR, WEIGHT, ItemExtra1,
                   ItemExtra2, ItemExtra3, MTRUNIT1, VAT, SODISCOUNT,
                   RELITEM, EXPN1, EXPN2, EXPN3, EXPVAL1, EXPVAL2, EXPVAL3);

             //   GlobalFunctions.updateCharQTYS(MTRL);
                imageUp.uploadItemImage(MTRL, CODE);

            }

            if (loadingProgressBar != null)
            {
                loadingProgressBar.Value = 0;
            }

        }


        public static void updateCharQTYS(String MTRL)
        {

            String postString = "";
            Settings settings = Settings.getInstance();
            String strQTY = "";
            String FILTER_CHECKBOX = "";
            String MTRL_SQL = "";
            S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();

            if (!MTRL.Equals(""))
            {
                MTRL_SQL = " AND MT.MTRL=" + MTRL + " ";
            }
            else
            {
                if (!settings.ITEM_ON_WEB.Equals(""))
                {
                    FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1 ";
                }
            }


            String sql = " SELECT " +
                  "   MT.CODE, " +
                  "   M.CDIM1, " +
                  "   M.CDIM2, " +
                  "   M.CDIM3, " +
                  "   M.CDIMLINES1, " +
                  "   M.CDIMLINES2, " +
                  "   M.CDIMLINES3, " +
                  "   SUM(M.OPNIMPQTY1+M.IMPQTY1-M.EXPQTY1) AS QTY " +
                  "   FROM  " +
                  "   ( CDIMFINDATA M INNER JOIN MTRL MT ON M.MTRL = MT.MTRL ) " +
                  "   INNER JOIN MTREXTRA ME ON ME.MTRL = MT.MTRL " +
                  "   WHERE  " +
                  "   M.COMPANY=" + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                  "   AND M.FISCPRD=" + S1Init.myXSupport.ConnectionInfo.YearId.ToString() +
                      FILTER_CHECKBOX +
                      MTRL_SQL +
                  "   GROUP BY  " +
                  "   MT.CODE, " +
                  "   M.CDIM1, " +
                  "   M.CDIMLINES1, " +
                  "   M.CDIMLINES2, " +
                  "   M.CDIMLINES3, " +
                  "   M.CDIM2, " +
                  "   M.CDIM3 ";

           // String s = S1Init.myXSupport.ConnectionInfo.YearId.ToString();

            XTable QTYREsults = S1Init.myXSupport.GetSQLDataSet(sql);

            for (int j = 0; j < QTYREsults.Count; j++)
            {
                strQTY +=
                    "&QTYS[a" + (j + 1) + "]="
                    + QTYREsults[j, "CDIM1"] + "~"
                    + QTYREsults[j, "CDIMLINES1"] + "~"
                    + QTYREsults[j, "CDIMLINES2"] + "~"
                    + QTYREsults[j, "CDIMLINES3"] + "~"
                    + QTYREsults[j, "QTY"] + "~"
                    + QTYREsults[j, "CODE"] + "~"
                    + QTYREsults[j, "CDIM2"] + "~"
                    + QTYREsults[j, "CDIM3"] + "~ " ;
            }

            itemHttp.syncCharQTY(strQTY);


        }



        public static void updateCharQTYSByMtrlsOnTransactions(String MTRL)
        {

            String postString = "";
            Settings settings = Settings.getInstance();
            String strQTY = "";
            String FILTER_CHECKBOX = "";
            String MTRL_SQL = "";
            S1Custom.Io.HttpWeb.ItemHttp itemHttp = new S1Custom.Io.HttpWeb.ItemHttp();

            if (!MTRL.Equals(""))
            {
                MTRL_SQL = " AND MT.MTRL=" + MTRL + " ";
            }
            else
            {
                if (!settings.ITEM_ON_WEB.Equals(""))
                {
                    FILTER_CHECKBOX = " AND ME." + settings.ITEM_ON_WEB + " = 1 ";
                }
            }


            String sql = " SELECT " +
                  "   MT.CODE, " +
                  "   M.CDIM1, " +
                  "   M.CDIM2, " +
                  "   M.CDIM3, " +
                  "   M.CDIMLINES1, " +
                  "   M.CDIMLINES2, " +
                  "   M.CDIMLINES3, " +
                  "   SUM(M.OPNIMPQTY1+M.IMPQTY1-M.EXPQTY1) AS QTY " +
                  "   FROM  " +
                  "   ( CDIMFINDATA M INNER JOIN MTRL MT ON M.MTRL = MT.MTRL ) " +
                  "   INNER JOIN MTREXTRA ME ON ME.MTRL = MT.MTRL " +
                  "   WHERE  " +
                  "   M.COMPANY=" + S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                  "   AND M.FISCPRD=" + S1Init.myXSupport.ConnectionInfo.YearId.ToString() +

                  "   AND  MT.MTRL IN (SELECT ML.MTRL FROM MTRLINES ML INNER JOIN FINDOC F ON F.FINDOC = ML.FINDOC WHERE F.TRNDATE >  DATEADD(day, -15, GETDATE()) ) " +
                  "   AND MT.SODTYPE = 51 " +
                      FILTER_CHECKBOX +
                      MTRL_SQL +
                  "   GROUP BY  " +
                  "   MT.CODE, " +
                  "   M.CDIM1, " +
                  "   M.CDIMLINES1, " +
                  "   M.CDIMLINES2, " +
                  "   M.CDIMLINES3, " +
                  "   M.CDIM2, " +
                  "   M.CDIM3 ";

            // String s = S1Init.myXSupport.ConnectionInfo.YearId.ToString();

            XTable QTYREsults = S1Init.myXSupport.GetSQLDataSet(sql);

            for (int j = 0; j < QTYREsults.Count; j++)
            {
                strQTY +=
                    "&QTYS[a" + (j + 1) + "]="
                    + QTYREsults[j, "CDIM1"] + "~"
                    + QTYREsults[j, "CDIMLINES1"] + "~"
                    + QTYREsults[j, "CDIMLINES2"] + "~"
                    + QTYREsults[j, "CDIMLINES3"] + "~"
                    + QTYREsults[j, "QTY"] + "~"
                    + QTYREsults[j, "CODE"] + "~"
                    + QTYREsults[j, "CDIM2"] + "~"
                    + QTYREsults[j, "CDIM3"] + "~ ";
            }

            itemHttp.syncCharQTY(strQTY);

        }






    }
}



                        /*  String name1 = "";
                        if (MTRLDATA[0, "CDIM1"] != "")
                        {
                            sql2 = " SELECT NAME,* FROM CDIMLINES " +
                                      " WHERE CDIM = " + MTRLDATA[0, "CDIM1"] +
                                      " AND CDIMLINES = " + words2[0] + " ";

                            XTable CDIMLINE1DATA = S1Init.myXSupport.GetSQLDataSet(sql2);
                            name1 = CDIMLINE1DATA[0, "NAME"].ToString();
                        }

                        String name2 = "";
                        if (MTRLDATA[0, "CDIM2"] != "")
                        {
                            sql2 = " SELECT NAME,* FROM CDIMLINES " +
                                        " WHERE CDIM = " + MTRLDATA[0, "CDIM2"] +
                                        " AND CDIMLINES = " + words2[1] + " ";

                            XTable CDIMLINE2DATA = S1Init.myXSupport.GetSQLDataSet(sql2);
                            name2 = CDIMLINE2DATA[0, "NAME"].ToString();
                        }

                        String name3 = "";
                        if (MTRLDATA[0, "CDIM3"] != "")
                        {
                            sql2 = " SELECT NAME,* FROM CDIMLINES " +
                                            " WHERE CDIM = " + MTRLDATA[0, "CDIM3"] +
                                            " AND CDIMLINES = " + words2[2] + " ";

                            XTable CDIMLINE3DATA = S1Init.myXSupport.GetSQLDataSet(sql3);
                            name3 = CDIMLINE3DATA[0, "NAME"].ToString();
                        } */

