using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary4.VIEW;
using Softone;

namespace ClassLibrary4.CONTROL
{
      [WorksOn("SALDOC")]
    class SALDOC : TXCode
    {
    //    SaldocRMenuFrm saldocRMenuFrm;

       /* public override void Initialize()
        {
            saldocRMenuFrm = new SaldocRMenuFrm(XSupport, XModule);
            saldocRMenuFrm.Visible = true;
            saldocRMenuFrm.TopLevel = false;

            XModule.InsertControl(saldocRMenuFrm, "*PAGE(CustomPanel,VWeb)");
        } */
          public override object ExecCommand(int Cmd)
          {
              switch (Cmd)
              {

                  case 201707193:
                      SaldocRMenuFrm frm = new SaldocRMenuFrm(XSupport, XModule);
                      frm.Visible = true;
                      break;


              }

              return base.ExecCommand(Cmd);
          }




    }
}
