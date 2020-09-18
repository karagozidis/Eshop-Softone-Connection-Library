using System;
using System.Collections.Generic;
using System.Text;
using Softone;
using System.Windows.Forms;

namespace S1Custom
{
    [WorksOn("PRCCATEGORY")]
    class PRCCategory : TXCode
    {
      //  static panel1 form1;
        static PRCCategoryForm pRCCategoryForm;
       // static panel2 p2;
        XTable CustTable;
        //IXTable TrdrTable;

        static int CallCount = 0;
        private void NameChanged(object Sender, XEventArgs e)
        {
            //    string s = string.Format("Name Changed to '{0}'", CustTable.Current["Name"]);
            //    MessageBox.Show(s);
        }

        private void checkActive(object Sender, XEventArgs e)
        {
            //  itemForm.checkIfActive();
        }

        public override void Initialize()
        {
            CustTable = XModule.GetTable("PRCCATEGORY");
         //   XModule.SetEvent("ON_TRDR_NAME", NameChanged);
          //  XModule.SetEvent("ON_TRDR_POST", NameChanged);
         //   form1 = new panel1();
            pRCCategoryForm = new PRCCategoryForm();
         //   p2 = new panel2();
            pRCCategoryForm.TopLevel = false;
            pRCCategoryForm.Visible = true;
            pRCCategoryForm.PRCCategory = CustTable;
           // XModule.InsertControl(itemForm, "+PANEL(Panel1,Web)");
            //XModule.InsertControl(itemForm, "+PANEL(NULL, 0,Web)"); 
            //XModule.SetEvent("ON_TRDR", checkActive);
            XModule.InsertControl(pRCCategoryForm, "+PAGE(Pl1,Web)");
            CallCount++;
        }

    }
}
