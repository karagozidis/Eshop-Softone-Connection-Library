using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary4.VIEW;
using Softone;

namespace ClassLibrary4.CONTROL
{
     [WorksOn("PURDOC")]
    class PURDOC : TXCode
    {

         public override object ExecCommand(int Cmd)
         {
             switch (Cmd)
             {
                 case 201707193:
                     PurdocRMenuFrm frm = new PurdocRMenuFrm(XSupport, XModule);
                     frm.Visible = true;
                     break;
             }

             return base.ExecCommand(Cmd);
         }



    }
}
