using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Softone;

namespace S1Custom
{
   /* [WorksOn("ITEM/S")]
    public class S1Customer : TXCode
    {
        public override void AfterPost()
        {
            base.AfterPost();
        }
    }


    [WorksOn("CUSTOMER/S")]
    public class SCustomer : TXCode
    {
        public override void Initialize()
        {
            MessageBox.Show("Hello from Server code");
        }
        IXTable t;

        public override void BeforePost()
        {
            t = XModule.GetTable("TRDR");
            MessageBox.Show((string)t[0, "CODE"]);
            base.BeforePost();
        }

        public override void AfterPost()
        {
            base.AfterPost();
        }

    } */
    
    [WorksOn("CUSTOMER")]
    public class Customer : TXCode
    {
        //static panel1 form1;
        static CustomerForm customerForm;
      //  static panel2 p2;
        XTable CustTable;
        XTable CustExtra;
        
        static int CallCount = 0;
        private void NameChanged(object Sender, XEventArgs e)
        {

        }

        private void UpdateUsernamePass(object Sender, XEventArgs e)
        {
        }

        public override void AfterPost()
        {
           // customerForm.syncOnSave();
        }

        
        public override void Initialize()
        {
            CustTable = XModule.GetTable("TRDR");
        
            customerForm = new CustomerForm();
            customerForm.TopLevel = false;
            customerForm.Visible = true;
            customerForm.TRDR = CustTable;

            XModule.InsertControl(customerForm, "+PAGE(PG8,Web)");
            

            CallCount++;
        }




    }
}


