using System;
using System.Collections.Generic;
using System.Text;
using Softone;
using System.Windows.Forms;

namespace S1Custom
{
   


    [WorksOn("ITEM")]
    public class Item : TXCode
    {
        static panel1 form1;
        static ItemForm itemForm;
        static panel2 p2;
        XTable CustTable;
        XTable CustTableExtra;
        //IXTable TrdrTable;
        static int CallCount = 0;


        private void NameChanged(object Sender, XEventArgs e)
        {
        //    string s = string.Format("Name Changed to '{0}'", CustTable.Current["Name"]);
       //     MessageBox.Show(s);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        //    MessageBox.Show("jjjjjjjjjjjjj");
        //    itemForm.test();
        } 


        private void checkActive(object Sender, XEventArgs e)
        {
          //  itemForm.checkIfActive();
        }

        public override void Initialize()
        {
            CustTable = XModule.GetTable("MTRL");
            CustTableExtra = XModule.GetTable("MTREXTRA");
        //    XModule.SetEvent("ON_MTRL_POST", NameChanged);
         //   XModule.SetEvent("ON_TRDR_POST", Page_Load);
            form1 = new panel1();
            itemForm = new ItemForm();
            p2 = new panel2();
            itemForm.TopLevel = false;

            itemForm.MTRL = CustTable;
            itemForm.MTREXTRA = CustTableExtra;

            itemForm.CompanyId = this.XSupport.ConnectionInfo.CompanyId;
            //itemForm.XSupport = this.XSupport;
              
          //  MessageBox.Show("SELECT A.COMPANY,A.PRCCATEGORY,A.CODE,A.NAME,A.ACNMSK,A.ISACTIVE,A.PRICEZONE " +
           //     "FROM [DEMO].[dbo].[PRCCATEGORY] A WHERE A.COMPANY=" + this.XSupport.ConnectionInfo.CompanyId + " ORDER BY A.PRCCATEGORY");

            XTable pRCCategories = this.XSupport.GetSQLDataSet(
                "SELECT A.COMPANY,A.PRCCATEGORY,A.CODE,A.NAME,A.ACNMSK,A.ISACTIVE,A.PRICEZONE " +
                "FROM PRCCATEGORY A WHERE A.COMPANY=" + this.XSupport.ConnectionInfo.CompanyId + " ORDER BY A.PRCCATEGORY"
                 );

            itemForm.pRCCategories = pRCCategories;
           // PRCCategories[1, 1].ToString();

           // itemForm.dataGridView1.VirtualMode = true;
           // itemForm.dataGridView1.RowCount = table1.Count;

                itemForm.Visible = true;



            XModule.InsertControl(itemForm, "+PAGE(PG8,Web)");

            //XModule.SetEvent("ON_TRDR", checkActive);
           
            CallCount++;
        }


    }




}
