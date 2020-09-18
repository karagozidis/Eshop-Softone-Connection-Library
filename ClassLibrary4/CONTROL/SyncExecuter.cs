using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary4.INOUT;
using S1Custom.Model;
using Softone;

namespace ClassLibrary4.CONTROL
{
   public static class SyncExecuter
    {

       //static TextBox resultsTextBox_;

       public static void ExecuteBricks()
       {
           String Sql =
            @" SELECT A.*
               FROM CCCCONNECTIONBRICK A
               WHERE A.COMPANY = "+S1Init.myXSupport.ConnectionInfo.CompanyId.ToString()+

            @" AND ACTIVE = 1 
               AND ONGENERALSYNC = 1
               ORDER BY A.EXECUTIONORDER ";

           XTable XResults = S1Init.myXSupport.GetSQLDataSet(Sql);

           for (int i = 0; i < XResults.Count; i++)
           {
               
               /* ExecuteBrick(
                            XResults[i, "SQLCOMMAND"].ToString(),
                            XResults[i, "WEBURL"].ToString(),
                            XResults[i, "ROWSONURL"].ToString(),
                            XResults[i, "WEBPARAMFORMAT"].ToString()
                            ); 
                */
               ExecuteBrick(
                           XResults[i, "CCCCONNECTIONBRICK"].ToString(),
                           ""
                           );
           }
       }


              
       public static void ExecuteBrick(String CONNECTIONBRICK, String IDGeneral, TextBox resultsTextBox = null)
       {

            String Sql = " SELECT A.* " +
                   " FROM CCCCONNECTIONBRICK A WHERE A.COMPANY=  " + S1Custom.Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                   " AND A.CCCCONNECTIONBRICK = " + CONNECTIONBRICK +            
                   " ORDER BY A.EXECUTIONORDER                                     ";

            XTable tbl = S1Custom.Model.S1Init.myXSupport.GetSQLDataSet(Sql);

            for (int i = 0; i < tbl.Count; i++)
            {

              Boolean execute = true;

               if (tbl[i,"EXECQUESTION"].ToString() != "")
               {
                   DialogResult dialogResult = MessageBox.Show(tbl[i,"EXECQUESTION"].ToString(), "Συνέχεια", MessageBoxButtons.YesNo);

                  if (dialogResult == DialogResult.No)
                       {
                           execute = false;
                       }

               }

               if (execute)
               {

                   if (tbl[i, "SPLITCALLPERID"].ToString() == "1")
                   {
                       string[] IDS = IDGeneral.Split(',');
                       foreach (var ID in IDS)
                       {
                           SyncExecuter.ExecuteBrickProcedure(
                           tbl[i, "SQLCOMMAND"].ToString().Replace("##id##", ID),
                           tbl[i, "WEBURL"].ToString(),
                           tbl[i, "ROWSONURL"].ToString(),
                           tbl[i, "WEBPARAMFORMAT"].ToString(),
                           tbl[i, "WEBPARAMFORMATSTATIC"].ToString(),
                           resultsTextBox,
                           tbl[i, "SPLITCALLPERSQLCOLUMN"].ToString()
                           );

                       }

                   }
                   else
                   {

                       SyncExecuter.ExecuteBrickProcedure(
                            tbl[i, "SQLCOMMAND"].ToString().Replace("##id##", IDGeneral),
                            tbl[i, "WEBURL"].ToString(),
                            tbl[i, "ROWSONURL"].ToString(),
                            tbl[i, "WEBPARAMFORMAT"].ToString(),
                            tbl[i, "WEBPARAMFORMATSTATIC"].ToString(),
                            resultsTextBox,
                            tbl[i, "SPLITCALLPERSQLCOLUMN"].ToString() 
                            );
                   }

                 String Sql2 = " SELECT A.* " +
                   " FROM CCCCONNECTIONBRICK A "+ 
                   " INNER JOIN CCCRELATEDCONNECTIONBRICK B ON B.RELCONNECTIONBRICKCODE  = A.CODE " + 
                   " WHERE A.COMPANY=  " + S1Custom.Model.S1Init.myXSupport.ConnectionInfo.CompanyId.ToString() +
                   " AND A.ACTIVE = 1                   "+
                   " AND B.CCCCONNECTIONBRICK =  " + CONNECTIONBRICK + 
                   " ORDER BY B.SHORTORDER,A.EXECUTIONORDER                                     ";

                     XTable tbl2 = S1Custom.Model.S1Init.myXSupport.GetSQLDataSet(Sql2);


                    for (int j = 0; j < tbl2.Count; j++)
                        {

                            if (tbl2[j, "SPLITCALLPERID"].ToString() == "1")
                            {
                                string[] IDS = IDGeneral.Split(',');
                                foreach (var ID in IDS)
                                {
                                SyncExecuter.ExecuteBrickProcedure(
                                  tbl2[j, "SQLCOMMAND"].ToString().Replace("##id##", ID),
                                  tbl2[j, "WEBURL"].ToString(),
                                  tbl2[j, "ROWSONURL"].ToString(),
                                  tbl2[j, "WEBPARAMFORMAT"].ToString(),
                                  tbl2[j, "WEBPARAMFORMATSTATIC"].ToString(),
                                  resultsTextBox
                                  );
                                }
                            }
                            else
                            {
                                SyncExecuter.ExecuteBrickProcedure(
                                   tbl2[j, "SQLCOMMAND"].ToString().Replace("##id##", IDGeneral),
                                   tbl2[j, "WEBURL"].ToString(),
                                   tbl2[j, "ROWSONURL"].ToString(),
                                   tbl2[j, "WEBPARAMFORMAT"].ToString(),
                                   tbl2[j, "WEBPARAMFORMATSTATIC"].ToString(),
                                   resultsTextBox
                                   );
                            }
                        }

               }


            }
 
       }  





       private static void ExecuteBrickProcedure(String SQLCOMMAND, String WEBURL, String ROWSONURL, String WEBPARAMFORMAT,
           String WEBPARAMFORMATSTATIC, TextBox resultsTextBox = null, String SPLITCALLPERSQLCOLUMN = "")
       {
           String Sql = SQLCOMMAND;

           Sql = Sql.Replace(":X.SYS.COMPANY", S1Init.myXSupport.ConnectionInfo.CompanyId.ToString());
           Sql = Sql.Replace(":X.SYS.FISCPRD", S1Init.myXSupport.ConnectionInfo.PeriodId.ToString());
           Sql = Sql.Replace(":X.SYS.BRANCH", S1Init.myXSupport.ConnectionInfo.BranchId.ToString());

           XTable XResults = S1Init.myXSupport.GetSQLDataSet(Sql);
           List<String> ColumnNames = getColumnNames(XResults);

           String PostParameters = "WC=12WWES254eepq35";

           String curSPLITCALLPERSQLCOLUMN = "";

           int ROWSONURLint = 1;
           int.TryParse(ROWSONURL,out ROWSONURLint);
           int RowsAddedCounter = 0;
           Boolean FirstRow = true;

           for (int i = 0; i < XResults.Count; i++)
           {
             
               if (WEBPARAMFORMAT != "")
               {

                  if(FirstRow)
                      {
                         String postParamaterSTATIC = WEBPARAMFORMATSTATIC;
                         foreach (string ColumnName in ColumnNames)
                                           {
                                               postParamaterSTATIC =
                                                  postParamaterSTATIC.Replace(
                                                                           ("##" + ColumnName + "##"),
                                                                           XResults[i, ColumnName].ToString()
                                                                       );
                                           }

                         PostParameters += postParamaterSTATIC;
                         FirstRow = false;
                     }

                   String postParamater = WEBPARAMFORMAT;

                   foreach (string ColumnName in ColumnNames)
                   {
                      postParamater = 
                          postParamater.Replace(
                                                   ("##" + ColumnName + "##"),
                                                   XResults[i, ColumnName].ToString()
                                               );
                   }

                   int vCounter = i + 1;
                 postParamater =  postParamater.Replace("##VCOUNTER##",vCounter.ToString());
                  

                   PostParameters += postParamater;
               }
               else
               {
                   String postParamater = "";
                   foreach (string ColumnName in ColumnNames)
                   {
                       postParamater += "&" + ColumnName + "=" + XResults[i, ColumnName].ToString();
                   }
                     PostParameters += postParamater;
               }

                 RowsAddedCounter++;
                 String SPLITCALLPERSQLCOLUMNVal = "";
                 if (SPLITCALLPERSQLCOLUMN != "") SPLITCALLPERSQLCOLUMNVal = XResults[i, SPLITCALLPERSQLCOLUMN].ToString();

               if (RowsAddedCounter == ROWSONURLint
                   || (curSPLITCALLPERSQLCOLUMN != "" && SPLITCALLPERSQLCOLUMN != "" && curSPLITCALLPERSQLCOLUMN != SPLITCALLPERSQLCOLUMNVal) 
                   )
              
                 {
                     String Result = WEBCALL.CALL(WEBURL, PostParameters);
                     if (resultsTextBox != null) resultsTextBox.Text +=  Result + "\r\n";
                     PostParameters = "WC=12WWES254eepq35";
                     RowsAddedCounter = 0;
                     FirstRow = true;
                 }

               if (SPLITCALLPERSQLCOLUMN != "") curSPLITCALLPERSQLCOLUMN = XResults[i, SPLITCALLPERSQLCOLUMN].ToString();
           }


           if (RowsAddedCounter > 0)
           {
               String Result = WEBCALL.CALL(WEBURL, PostParameters);
               if (resultsTextBox != null) resultsTextBox.Text += Result + "\r\n";

           }

       }


       private static List<String> getColumnNames(XTable tbl)
             {
                 List<String> ColumnNames = new List<string>();
                    for (int k = 1; k <= tbl.FieldCount; k++)
                    {
                        ColumnNames.Add(tbl.FieldName(k));
                    }

                    return ColumnNames;
            }





    }
}
