using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary4.VIEW;
using Softone;

namespace ClassLibrary4.CONTROL
{
    [WorksOn("CCCItemRMenu")]
    class CCCItemRMenu : TXCode
    {
        ItemRMenuFrm itemRMenuFrm;
        // TestFrm t; 

        public override void Initialize()
        {
            itemRMenuFrm = new ItemRMenuFrm(XSupport, XModule);
            itemRMenuFrm.Visible = true;
            itemRMenuFrm.TopLevel = false;

            XModule.InsertControl(itemRMenuFrm, "*PAGE(CustomPanel,VWeb)");
        }
    }
}
