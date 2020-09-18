using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Softone;

namespace S1Custom.Model
{

    [WorksOn("PPRMS")]
    class Btbpprms : TXCode
    {
      //  static panel1 form1;
        static CustomerForm customerForm;
      //  static panel2 p2;
        XTable CustTable;
        //IXTable TrdrTable;

        static int CallCount = 0;
        private void NameChanged(object Sender, XEventArgs e)
        {
            string s = string.Format("Name Changed to '{0}'", CustTable.Current["Name"]);
            //            CallCount = CustTable.Current.RecNo;
            MessageBox.Show(s);
        }

        private void checkActive(object Sender, XEventArgs e)
        {
            customerForm.checkIfActive();
            // MessageBox.Show(s);
        }

        public override void Initialize()
        {

            CustTable = XModule.GetTable("TRDR");
            // MessageBox.Show((String)CustTable.Current["EMAIL"]);
            XModule.SetEvent("ON_TRDR_NAME", NameChanged);
            XModule.SetEvent("ON_TRDR_POST", NameChanged);
       //     form1 = new panel1();
            customerForm = new CustomerForm();
       //     p2 = new panel2();
            customerForm.TopLevel = false;
            customerForm.Visible = true;
            customerForm.TRDR = CustTable;
            XModule.InsertControl(customerForm, "+PAGE(PG2,Web)");

            XModule.SetEvent("ON_TRDR", checkActive);

            CallCount++;
        }

    }
}
