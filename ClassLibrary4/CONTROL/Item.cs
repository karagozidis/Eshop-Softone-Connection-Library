using System;
using System.Collections.Generic;
using System.Text;
using Softone;
using System.Windows.Forms;
using ClassLibrary4.VIEW;

namespace S1Custom
{
   
    [WorksOn("ITEM")]
    public class Item : TXCode
    {
        static ItemForm itemForm;
        XTable ItemTable;
        XTable ItemTableExtra;

        static int CallCount = 0;


       // private void NameChanged(object Sender, XEventArgs e)
       // {
       // }


       // protected void Page_Load(object sender, EventArgs e)
       // {
       // } 


       // private void checkActive(object Sender, XEventArgs e)
       // {
       // }


        //public override void AfterPost()
        //{
        //    itemForm.syncOnSave();
        //}

        public override void Initialize()
        {
            ItemTable = XModule.GetTable("MTRL");
            itemForm = new ItemForm();
            itemForm.TopLevel = false;
            itemForm.MTRL = ItemTable;
            itemForm.Visible = true;

            XModule.InsertControl(itemForm, "+PAGE(PG8,Web)");

            CallCount++;
        }



        public override object ExecCommand(int Cmd)
        {
            switch (Cmd)
            {
                case 201707193:
                    ItemRMenuFrm frm = new ItemRMenuFrm(XSupport, XModule);
                    frm.Visible = true;
                    break;
            }

            return base.ExecCommand(Cmd);
        }



    }




}
