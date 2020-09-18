using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S1Custom.View;
using Softone;

namespace S1Custom.Model
{
   // [WorksOn("SALDOC")]
    class Order //: TXCode
    {

        public int CustomerCodeToTrdr(String customerCode)
        { 
        int CustID = -1; 

         XTable CUSTOMER_MTRL =  Model.S1Init.myXSupport.GetSQLDataSet("SELECT TRDR "+
            " FROM TRDR  WHERE COMPANY= " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId +
            " AND SODTYPE=13 AND CODE = '" + customerCode + "'"
            );

         if (CUSTOMER_MTRL.Count == 1) CustID = Convert.ToInt32(CUSTOMER_MTRL[0, "TRDR"].ToString());

         return CustID;
        }


        public int ItemCodeToMtrl(String ItemCode)
        {
            int ItemID = -1;

            XTable CUSTOMER_MTRL = Model.S1Init.myXSupport.GetSQLDataSet("SELECT MTRL " +
               " FROM MTRL  WHERE COMPANY= " + Model.S1Init.myXSupport.ConnectionInfo.CompanyId +
               " AND SODTYPE=51 AND CODE = '" + ItemCode + "'"
               );

            if (CUSTOMER_MTRL.Count == 1) ItemID = Convert.ToInt32(CUSTOMER_MTRL[0, "MTRL"].ToString());

            return ItemID;
        }


        public void InsSalDocToS1(int FinDocID, int CustID, ArrayList items, double shippingPrice, int EXPN)
        {

            XModule ModuleSALDOC = Model.S1Init.myXSupport.CreateModule("SALDOC");
            XTable FinDoc = ModuleSALDOC.GetTable("FINDOC");
            XTable IteLines = ModuleSALDOC.GetTable("ITELINES");
            XTable MtrDoc = ModuleSALDOC.GetTable("MTRDOC");

            XTable EXPANAL = ModuleSALDOC.GetTable("EXPANAL");

            try
            {
                ModuleSALDOC.InsertData();
                FinDoc.Current["SERIES"] = FinDocID;
                FinDoc.Current["FPRMS"] = FinDocID;
                FinDoc.Current["TFPRMS"] = 202;
                FinDoc.Current["SOSOURCE"] = 1351;
                FinDoc.Current["TRNDATE"] = DateTime.Today;
                FinDoc.Current["TRDR"] = CustID;
                FinDoc.Current["VATSTS"] = 1;
                FinDoc.Current["FISCPRD"] = 2015;
                FinDoc.Current["BRANCH"] = 1000;
               // FinDoc.Current["VAT"] = 1;

                //FinDoc.Current.Post();

                //MtrDoc.Current.Insert();
                MtrDoc.Current["WHOUSE"] = 1000;
                //MtrDoc.Current.Post();

                int linenum = 1;
                foreach (ArrayList item in items)
                    {
                        IteLines.Current.Insert();

                        IteLines.Current["LINENUM"] = linenum;
                        IteLines.Current["SODTYPE"] = 51;
                    //    IteLines.Current["SOSOURCE"] = 1351;
                        IteLines.Current["MTRL"] = (int)item[5];
                        IteLines.Current["MTRUNIT"] = 1;            //Your code 
                        IteLines.Current["QTY1"] = Convert.ToDouble(item[2].ToString().Replace(".",","));
                       // IteLines.Current["QTY1"] = 1.00;
                    //    IteLines.Current["VAT"] = 1310;              //Your Code
                        IteLines.Current["LINEVAL"] = Convert.ToDouble(item[4].ToString().Replace(".", ","));
                        IteLines.Current["PRICE"] = Convert.ToDouble(item[3].ToString().Replace(".", ","));
                        IteLines.Current["DISC1PRC"] = 0.00;

                        IteLines.Current.Post();
                        linenum++;
                    }


                if (shippingPrice > 0)
                    {
                    EXPANAL.Current.Insert();
                    EXPANAL.Current["EXPN"] = EXPN;
                    EXPANAL.Current["EXPVAL"] = shippingPrice;
                    //EXPANAL.Current[""] = 
                    //EXPANAL.Current[""] = 
                    EXPANAL.Current.Post();
                    }
                
                FinDoc.Current.Post();

                ModuleSALDOC.PostData();
            }
            catch (Exception ex)
            {
                throw ex;
              //  MessageBox.Show(e.Message);
            }
        }


        static S1CustomOrderForm orderForm;
        XTable CustTable;
        static int CallCount = 0;

      /*  public override void Initialize()
        {
            CustTable = XModule.GetTable("FINDOC");

           // InsSalDocToS1(7021, 100, 2131);

           // CustTable.CreateDataTable
            orderForm = new S1CustomOrderForm();
            orderForm.TopLevel = false;

           // orderForm.MTRL = CustTable;
          //  orderForm.CompanyId = this.XSupport.ConnectionInfo.CompanyId;

            XModule.InsertControl(orderForm, "+PAGE(Page4,Web)");

          

            CallCount++;
        } */

    }
}
