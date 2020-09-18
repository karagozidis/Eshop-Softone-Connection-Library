using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Softone;

namespace ClassLibrary4.CONTROL
{
    [WorksOn("CCCCONNECTIONBRICKobj")]
    class CCCCONNECTIONBRICKobj : TXCode
    {
        XTable CCCCONNECTIONBRICK;
        XTable CCCSQLCOMMANDCOLUMN;
        public XSupport curSupport;

        public override void Initialize()
        {
            curSupport = XSupport;
            CCCCONNECTIONBRICK = XModule.GetTable("CCCCONNECTIONBRICK");
            CCCSQLCOMMANDCOLUMN = XModule.GetTable("CCCSQLCOMMANDCOLUMN");       
        }


        public override object ExecCommand(int Cmd)
        {
            switch (Cmd)
            {
                case 150005:

                    String SqlCommand = CCCCONNECTIONBRICK.Current["SQLCOMMAND"].ToString();

                    SqlCommand = SqlCommand.Replace(":X.SYS.COMPANY", "1");
                    SqlCommand = SqlCommand.Replace(":X.SYS.FISCPRD", "1");
                    SqlCommand = SqlCommand.Replace(":X.SYS.BRANCH", "1");
                    SqlCommand = SqlCommand.Replace("WHERE ", " WHERE 1=0 AND ");

                    XTable tbl = this.curSupport.GetSQLDataSet(SqlCommand);

                    for (int k = 1; k <= tbl.FieldCount; k++)
                    {
                        String FieldName = tbl.FieldName(k);
                        CCCSQLCOMMANDCOLUMN.Current.Insert();
                        CCCSQLCOMMANDCOLUMN.Current["COLUMNNAME"] = FieldName;
                        CCCSQLCOMMANDCOLUMN.Current.Post();
                    }

                break;
            }

            return Cmd;
        }


    }






}
