using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary4.VIEW;
using Softone;

namespace ClassLibrary4
{
    [WorksOn("CCCCustomerRMenu")]
    class CCCCustomerRMenu : TXCode
    {

        
        CustomerRMenuFrm customerRMenuFrm;
       // TestFrm t; 

        public override void Initialize()
        {
            customerRMenuFrm = new CustomerRMenuFrm(XSupport, XModule);
            customerRMenuFrm.Visible = true;
            customerRMenuFrm.TopLevel = false;
             
             XModule.InsertControl(customerRMenuFrm, "*PAGE(CustomPanel,VWeb)");


        }
    }
}
