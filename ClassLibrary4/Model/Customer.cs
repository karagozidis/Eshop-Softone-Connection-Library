using System;
using System.Collections.Generic;
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
        static panel2 p2;
        XTable CustTable;
        XTable CustExtra;
        
        static int CallCount = 0;
        private void NameChanged(object Sender, XEventArgs e)
        {
            string s = string.Format("Name Changed to '{0}'", CustTable.Current["Name"]);
            //MessageBox.Show(s);
        }

        private void UpdateUsernamePass(object Sender, XEventArgs e)
        {
        }

        private void checkActive(object Sender, XEventArgs e)
        {
            customerForm.checkIfActive();
           // MessageBox.Show(s);
        }
        
        public override void Initialize()
        {
    
            CustTable = XModule.GetTable("TRDR");
           // CustExtra = XModule.GetTable("TRDEXTRA");
           // MessageBox.Show((String)CustTable.Current["EMAIL"]);
          //  XModule.SetEvent("ON_TRDR_NAME", NameChanged);
           // XModule.SetEvent("ON_TRDR_POST", NameChanged);

        //    MessageBox.Show("Hello");
           // XModule.SetEvent("ON_TRDR_POST", UpdateUsernamePass);
            //p2 = new panel2();
          //  form1 = new panel1();
            customerForm = new CustomerForm();
            
            customerForm.TopLevel = false;
            customerForm.Visible = true;
            customerForm.TRDR = CustTable;
            XModule.InsertControl(customerForm, "+PAGE(PG8,Web)");
           
           // XModule.SetEvent("ON_TRDR", checkActive);

            CallCount++;
        }


        public override void BeforePost()
        {
            MessageBox.Show("BeforePost");
            base.BeforePost();
        }


    /*    public override void Initialize()
        {

            CustTable = XModule.GetTable("TRDR");

            XModule.SetEvent("ON_TRDR_NAME", NameChanged);
            XModule.SetEvent("ON_TRDR_POST", NameChanged);
            form1 = new panel1();
            form2 = new Form2();
            p2 = new panel2();
            form2.TopLevel = false;
            form2.Visible = true;
            form2.t = CustTable;
//            form2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            form2.Dock = System.Windows.Forms.DockStyle.Fill;
//            p2.Controls.Add(form2);
//            form2.ShowInTaskbar = false;
//            form2.Show();
            XModule.InsertControl(form2, "+PAGE(PG8,Σύνδεση με Ιστοσελίδα)");
            CallCount++;
        }*/

    }
}


